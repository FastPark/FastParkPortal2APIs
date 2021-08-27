using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Data.SqlClient;

namespace Portal2APIs.Controllers
{
    public class CombineMemberCardsController : ApiController
    {
        [HttpPost]
        [Route("api/CombineMemberCardsController/CombineMemberCards/")]
        public string CombineMemberCards(CombineMemberCard cardsToCombine)
        {
            try
            {
                Int32 targetMemberId = new Int32();
                Int32 originMemberId = new Int32();
                Int32 targetBeginningBalance = new Int32();
                Int32 originBeginningBalance = new Int32();

                clsADO thisADO = new clsADO();

                //Get back out Batch
                var backOutBatchSQL = "Select Max(Batch) + 1 from CardCombineBackOut";
                var backoutBatch = thisADO.returnSingleValueForInternalAPIUse(backOutBatchSQL, false);

                targetMemberId = Convert.ToInt32(thisADO.returnSingleValueForInternalAPIUse("select MemberId from MemberCard where FPNumber = '" + cardsToCombine.TargetCard + "'", false));
                originMemberId = Convert.ToInt32(thisADO.returnSingleValueForInternalAPIUse("select MemberId from MemberCard where FPNumber = '" + cardsToCombine.OriginCard + "'", false));

                if (targetMemberId == 0 || originMemberId == 0)
                {
                    return "There was an issue with one of the cards.  Please note the cards and send the issue to IT.  Thanks.";

                }

                if (targetMemberId == originMemberId)
                {
                    return "The same MemberID was returned from the entered cards.  Please contact IT with the card numbers for investigation.";
                }

                //Back Out for Cards gets original state of cards. +++++++++++++++++++++++++++++++++
                var cardBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberCard set MemberId = ' + Convert(nvarchar(max), MemberId) + ', IsPrimary = ' + Convert(nvarchar(2), IsPrimary) + ', IsActive = ' + Convert(nvarchar(2), IsActive) + ', UpdateDateTime = GetDate() where CardId = ' + Convert(nvarchar(max), CardId), " + backoutBatch + " " +
                                    "from MemberCard " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(cardBackOutSQL, false);
                thisADO.updateOrInsert(cardBackOutSQL, true);

                cardBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberCard set MemberId = ' + Convert(nvarchar(max), MemberId) + ', IsPrimary = ' + Convert(nvarchar(2), IsPrimary) + ', IsActive = ' + Convert(nvarchar(2), IsActive) + ', UpdateDateTime = GetDate() where CardId = ' + Convert(nvarchar(max), CardId), " + backoutBatch + " " +
                                    "from MemberCard " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(cardBackOutSQL, false);
                thisADO.updateOrInsert(cardBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //Set target card as primary
                thisADO.updateOrInsert("Update MemberCard set IsPrimary = 1 where FPNumber = " + cardsToCombine.TargetCard, true);
                //Set memberId of origin memberCard to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update MemberCard set MemberId = " + targetMemberId + ", IsPrimary = 0 where FPNumber = " + cardsToCombine.OriginCard, true);
                //Set all remaining cards from orig memberId to target memberId
                thisADO.updateOrInsert("Update MemberCard set MemberId = " + targetMemberId + ", IsPrimary = 0 where MemberId = " + originMemberId, true);

                //Back Out for MemberInformation gets original state of member+++++++++++++++++++++++
                var memberInfoBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberInformationMain set EmailStatus = ' + Convert(nvarchar(max), EmailStatus) + ', IsDeleted = ' + Convert(nvarchar(2), IsDeleted) + ', EmailAddress = ''' + EmailAddress + ''', UpdateDateTime = GetDate() where MemberId = ' + Convert(nvarchar(max), MemberId), " + backoutBatch + " " +
                                    "from MemberInformationMain " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(memberInfoBackOutSQL, false);
                thisADO.updateOrInsert(memberInfoBackOutSQL, true);

                memberInfoBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberInformationMain set EmailStatus = ' + Convert(nvarchar(max), EmailStatus) + ', IsDeleted = ' + Convert(nvarchar(2), IsDeleted) + ', EmailAddress = ''' + EmailAddress + ''', UpdateDateTime = GetDate() where MemberId = ' + Convert(nvarchar(max), MemberId), " + backoutBatch + " " +
                                    "from MemberInformationMain " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(memberInfoBackOutSQL, false);
                thisADO.updateOrInsert(memberInfoBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //set email status and dateupdated for both member accounts and set deleted for origin
                thisADO.updateOrInsert("Update MemberInformationMain set EmailStatus = 7, UpdateDatetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' where MemberId = " + targetMemberId, true);
                thisADO.updateOrInsert("Update MemberInformationMain set EmailStatus = 0, EmailAddress = '', UpdateDatetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' where MemberId = " + originMemberId, true);
                thisADO.updateOrInsert("Update MemberInformationMain set IsDeleted = 1 where MemberId = " + originMemberId, true);

                //Back Out for Activity gets original state of Activity+++++++++++++++++++++++
                var ActivityBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Activity set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ParkingTransactionNumber = ''' + ParkingTransactionNumber + '''', " + backoutBatch + " " +
                                    "from Activity " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(ActivityBackOutSQL, false);
                thisADO.updateOrInsert(ActivityBackOutSQL, true);

                ActivityBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Activity set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ParkingTransactionNumber = ''' + ParkingTransactionNumber + '''', " + backoutBatch + " " +
                                    "from Activity " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(ActivityBackOutSQL, false);
                thisADO.updateOrInsert(ActivityBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Set memberId of origin activity to target MemberId and do on both remote and local since it does not sync
                thisADO.updateOrInsert("Update Activity set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, false);
                thisADO.updateOrInsert("Update Activity set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Back Out for ManualEdits gets original state of ManualEdits+++++++++++++++++++++++
                var manualEditBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update ManualEdits set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ManualEditID = ' + Convert(nvarchar(max), ManualEditID), " + backoutBatch + " " +
                                    "from ManualEdits " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(manualEditBackOutSQL, false);
                thisADO.updateOrInsert(manualEditBackOutSQL, true);

                manualEditBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update ManualEdits set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ManualEditID = ' + Convert(nvarchar(max), ManualEditID), " + backoutBatch + " " +
                                    "from ManualEdits " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(manualEditBackOutSQL, false);
                thisADO.updateOrInsert(manualEditBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Set memberId of origin Manual Edits to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update ManualEdits set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Back Out for Reservations gets original state of Reservations+++++++++++++++++++++++
                var reservationBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Reservations set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ReservationId = ' + Convert(nvarchar(max), ReservationId), " + backoutBatch + " " +
                                    "from Reservations " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(reservationBackOutSQL, false);
                thisADO.updateOrInsert(reservationBackOutSQL, true);

                reservationBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Reservations set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where ReservationId = ' + Convert(nvarchar(max), ReservationId), " + backoutBatch + " " +
                                    "from Reservations " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(reservationBackOutSQL, false);
                thisADO.updateOrInsert(reservationBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Set memberId of origin Reservations to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update Reservations set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Back Out for Redemptions gets original state of Redemptions+++++++++++++++++++++++
                var redemptionBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Redemptions set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where RedemptionId = ' + Convert(nvarchar(max), RedemptionId), " + backoutBatch + " " +
                                    "from Redemptions " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(redemptionBackOutSQL, false);
                thisADO.updateOrInsert(redemptionBackOutSQL, true);

                redemptionBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update Redemptions set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where RedemptionId = ' + Convert(nvarchar(max), RedemptionId), " + backoutBatch + " " +
                                    "from Redemptions " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(redemptionBackOutSQL, false);
                thisADO.updateOrInsert(redemptionBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Set memberId of origin Redemptions to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update Redemptions set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Back Out for BeginningPoints gets original state of BeginningPoints+++++++++++++++++++++++
                var beginningBalanceBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberBeginningBalance set BeginningPoints = ' + Convert(nvarchar(max), BeginningPoints) + ' where MemberId = ' + Convert(nvarchar(max), MemberId), " + backoutBatch + " " +
                                    "from MemberBeginningBalance " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(beginningBalanceBackOutSQL, false);
                thisADO.updateOrInsert(beginningBalanceBackOutSQL, true);

                beginningBalanceBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberBeginningBalance set BeginningPoints = ' + Convert(nvarchar(max), BeginningPoints) + ' where MemberId = ' + Convert(nvarchar(max), MemberId), " + backoutBatch + " " +
                                    "from MemberBeginningBalance " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(beginningBalanceBackOutSQL, false);
                thisADO.updateOrInsert(beginningBalanceBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Get beginning balance for both target and origin
                targetBeginningBalance = Convert.ToInt32(thisADO.returnSingleValueForInternalAPIUse("select BeginningPoints from MemberBeginningBalance where MemberId = " + targetMemberId, true));
                originBeginningBalance = Convert.ToInt32(thisADO.returnSingleValueForInternalAPIUse("select BeginningPoints from MemberBeginningBalance where MemberId = " + originMemberId, true));

                //add both balances together
                Int32 newBeginningBalance = new Int32();
                newBeginningBalance = targetBeginningBalance + originBeginningBalance;

                //set target point balance to the sum of the the balances on both remote and local
                thisADO.updateOrInsert("Update MemberBeginningBalance set BeginningPoints = " + newBeginningBalance + " where MemberId = " + targetMemberId, false);
                thisADO.updateOrInsert("Update MemberBeginningBalance set BeginningPoints = " + newBeginningBalance + " where MemberId = " + targetMemberId, true);

                //set orignin point balance to 0 on both remote and local
                thisADO.updateOrInsert("Update MemberBeginningBalance set BeginningPoints = 0 where MemberId = " + originMemberId, false);
                thisADO.updateOrInsert("Update MemberBeginningBalance set BeginningPoints = 0 where MemberId = " + originMemberId, true);

                //Back Out for BeginningPoints gets original state of BeginningPoints+++++++++++++++++++++++
                var memberVisitBackOutSQL = "Insert into CardCombineBackOut " +
                                            "Select 'Delete from MemberVisitTracking where MemberId = " + originMemberId + "', " + backoutBatch;
                thisADO.updateOrInsert(memberVisitBackOutSQL, false);
                thisADO.updateOrInsert(memberVisitBackOutSQL, true);

                memberVisitBackOutSQL = "Insert into CardCombineBackOut " +
                                        "Select 'exec dbo.UpdateMarketingTrackingNewByMember " + originMemberId + "', " + backoutBatch;
                thisADO.updateOrInsert(memberVisitBackOutSQL, false);
                thisADO.updateOrInsert(memberVisitBackOutSQL, true);

                memberVisitBackOutSQL = "Insert into CardCombineBackOut " +
                                        "Select 'exec dbo.UpdateMarketingTrackingNewByMember " + targetMemberId + "', " + backoutBatch;
                thisADO.updateOrInsert(memberVisitBackOutSQL, false);
                thisADO.updateOrInsert(memberVisitBackOutSQL, true);
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Delete all marketing visit tracking for target account
                thisADO.updateOrInsert("Delete from MemberVisitTracking where MemberId = " + targetMemberId, false);

                //Set IsCombined = 1 in marketing visit tracking for origin MemberId
                thisADO.updateOrInsert("Update MemberVisitTracking set IsCombined = 1 where MemberId = " + originMemberId, false);
                
                //Call stored procedure to run the visit tracking on this target members ID on remote it gets synced
                thisADO.UpdateMemberVisitTracking(targetMemberId, false);


                //Uncommented MemberNote combine 08/26/2021 request Betsi email and Spiceworks ticket 5728. 
                //Commented out to leave note with original 6/26/2019
                //Back Out for MemberNotes gets original state of MemberNotes+++++++++++++++++++++++
                var noteBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberNotes set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where NotesId = ' + Convert(nvarchar(max), NotesId), " + backoutBatch + " " +
                                    "from MemberNotes " +
                                    "where memberid = " + originMemberId;
                thisADO.updateOrInsert(noteBackOutSQL, false);
                thisADO.updateOrInsert(noteBackOutSQL, true);

                noteBackOutSQL = "Insert into CardCombineBackOut " +
                                    "Select 'Update MemberNotes set MemberId = ' + Convert(nvarchar(max), MemberId) + ' where NotesId = ' + Convert(nvarchar(max), NotesId), " + backoutBatch + " " +
                                    "from MemberNotes " +
                                    "where memberid = " + targetMemberId;
                thisADO.updateOrInsert(noteBackOutSQL, false);
                thisADO.updateOrInsert(noteBackOutSQL, true);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Set memberId of origin MemberNotes to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update MemberNotes set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //add note for backout++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                noteBackOutSQL = "Insert into CardCombineBackOut " +
                                        "Select 'Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) values (" + originMemberId + ",''Member Card " + cardsToCombine.OriginCard + " was uncombined from " + cardsToCombine.TargetCard + " on '' + Convert(nvarchar,GetDate(), 101) + '' by check change log'', Convert(nvarchar,GetDate(), 101), -1, Convert(nvarchar,GetDate(), 101), -1)', " + backoutBatch;
                thisADO.updateOrInsert(noteBackOutSQL, false);
                thisADO.updateOrInsert(noteBackOutSQL, true);

                noteBackOutSQL = "Insert into CardCombineBackOut " +
                                        "Select 'Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) values (" + targetMemberId + ",''Member Card " + cardsToCombine.OriginCard + " was uncombined from " + cardsToCombine.TargetCard + " on '' + Convert(nvarchar,GetDate(), 101) + '' by check change log'', Convert(nvarchar,GetDate(), 101) , -1, Convert(nvarchar,GetDate(), 101), -1)', " + backoutBatch;
                thisADO.updateOrInsert(noteBackOutSQL, false);
                thisADO.updateOrInsert(noteBackOutSQL, true);
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Add note to target member account
                thisADO.updateOrInsert("Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                       "values (" + targetMemberId + ",'Member Card " + cardsToCombine.OriginCard + " was combined into " + cardsToCombine.TargetCard + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + " back out is " + backoutBatch + "', " +
                                       " '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', '" + cardsToCombine.CombinedBy + "', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', -1)", true);

                //Add note to origin member account
                thisADO.updateOrInsert("Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                       "values (" + originMemberId + ",'Member Card " + cardsToCombine.OriginCard + " was combined into " + cardsToCombine.TargetCard + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + " back out is " + backoutBatch + "', " +
                                       " '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', '" + cardsToCombine.CombinedBy + "', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', -1)", true);

                //Add note to target changelog
                string strInsertLogSQL = "Insert into changeLog " + "(changeUser, changeDate, changeID, changeValOld, changeValNew, changeTable, changeNote, changeBatch, CreateUserId) " +
                     "Values ('" + cardsToCombine.CombinedBy + "', '" + DateTime.Now + "', '" + originMemberId + "', '" + originMemberId + "', '" + targetMemberId + "', '" +
                              "" + "', '" + "MemberId " + originMemberId + " was combined with " + targetMemberId + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + "', 0, -1)";

                thisADO.updateOrInsert(strInsertLogSQL, true);

                //Add note to target changelog
                strInsertLogSQL = "Insert into changeLog " + "(changeUser, changeDate, changeID, changeValOld, changeValNew, changeTable, changeNote, changeBatch, CreateUserId) " +
                     "Values ('" + cardsToCombine.CombinedBy + "', '" + DateTime.Now + "', '" + targetMemberId + "', '" + originMemberId + "', '" + targetMemberId + "', '" +
                              "" + "', '" + "MemberId " + originMemberId + " was combined with " + targetMemberId + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + "', 0, -1)";

                thisADO.updateOrInsert(strInsertLogSQL, true);

                return "Members cards have been combined!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
        
        [HttpPost]
        [Route("api/CombineMemberCardsController/CombineCardsWithRollBack/")]
        public string CombineCardsWithRollBack(CombineMemberCard cardsToCombine)
        {
            clsADO thisADO = new clsADO();

            string sourceCard = cardsToCombine.OriginCard;
            string targetCard = cardsToCombine.TargetCard;
            string strSQL = "";
            string sourceMemberId = "";
            string targetMemberId = "";
            string checkAddress = "";
            string verifyAddress = "";
            string sourceEmailAddress = "";  //for logging
            int targetBeginningBalance = 0;
            int sourceBeginningBalance = 0;
            int newBeginningBalance = 0;

            using (SqlConnection con1 = new SqlConnection(thisADO.getLocalConnectionString()))
            {
                using (SqlCommand cmd1 = new SqlCommand())
                {
                    con1.Open();
                    SqlCommand command1 = con1.CreateCommand();
                    SqlTransaction transaction1;

                    // Start a local transaction.
                    transaction1 = con1.BeginTransaction("Transaction1");

                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    command1.Connection = con1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //These first queries don't need to be part of the transaction since they are just selects
                        //If they fail they will pop out to the catch and end the function
                        //Get MemberIds from Cards
                        strSQL = "select MemberId from MemberCard where FPNumber = " + sourceCard;
                        sourceMemberId = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);
                        strSQL = "select MemberId from MemberCard where FPNumber = " + targetCard;
                        targetMemberId = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                        //Make sure cards exist on local
                        if (sourceMemberId == "" || targetMemberId == "")
                        {
                            return "Member does not exist on the local server.  Please try again tomorrow.";
                        }

                        //check for duplicate email
                        strSQL = "Select EmailAddress from MemberInformationMain where MemberId = " + targetMemberId;
                        checkAddress = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                        strSQL = "Select MemberId from MemberInformationMain where EmailAddress = '" + checkAddress + "' " +
                                 "And MemberId <> " + targetMemberId;
                        verifyAddress = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                        if (verifyAddress != null)
                        {
                            return "Member has a duplicate email in the database.";
                        }

                        //get source email address for logging
                        strSQL = "Select EmailAddress from MemberInformationMain where MemberId = " + sourceMemberId;
                        sourceEmailAddress = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                        //get beginningBalances
                        strSQL = "select BeginningPoints " +
                                "from MemberBeginningBalance " +
                                "where MemberId = " + sourceMemberId;
                        sourceBeginningBalance = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, false));

                        strSQL = "select BeginningPoints " +
                                "from MemberBeginningBalance " +
                                "where MemberId = " + targetMemberId;
                        targetBeginningBalance = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, false));

                        newBeginningBalance = sourceBeginningBalance + targetBeginningBalance;

                        //Incluced in rollback since it is an upate - set source Activity memberId to target memberId
                        command1.CommandText = "Update Activity set MemberId = " + targetMemberId + "where MemberId = " + sourceMemberId;
                        command1.ExecuteNonQuery();

                        //Incluced in rollback since it is an upate - set target Beginning Points
                        command1.CommandText = "Update MemberBeginningBalance set BeginningPoints = " + newBeginningBalance + "where MemberId = " + targetMemberId;
                        command1.ExecuteNonQuery();

                        //Incluced in rollback since it is an upate - set source Beginning Points
                        command1.CommandText = "Update MemberBeginningBalance set BeginningPoints = 0 where MemberId = " + sourceMemberId;
                        command1.ExecuteNonQuery();

                        //Incluced in rollback since it is an upate - Delete all target member tracking
                        command1.CommandText = "Delete from MemberVisitTracking where MemberId = " + targetMemberId;
                        command1.ExecuteNonQuery();

                        //Incluced in rollback since it is an upate - Set all orig member tracking to IsCombined
                        command1.CommandText = "Update MemberVisitTracking set IsCombined = 1 where MemberId = " + sourceMemberId;
                        command1.ExecuteNonQuery();

                        using (SqlConnection con2 = new SqlConnection(thisADO.getRemoteConnectionString()))
                        {
                            using (SqlCommand cmd2 = new SqlCommand())
                            {
                                con2.Open();
                                SqlCommand command2 = con2.CreateCommand();
                                SqlTransaction transaction2;

                                // Start a local transaction.
                                transaction2 = con2.BeginTransaction("Transaction2");

                                // Must assign both transaction object and connection
                                // to Command object for a pending local transaction
                                command2.Connection = con2;
                                command2.Transaction = transaction2;

                                try
                                {
                                    // set all source members cards to target member
                                    command2.CommandText = "Update MemberCard " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where FPNumber = '" + sourceCard + "'";
                                    command2.ExecuteNonQuery();

                                    // set all cards to not primary
                                    command2.CommandText = "Update MemberCard " +
                                                           "set IsPrimary = 0 " +
                                                           "where MemberId = " + targetMemberId;
                                    command2.ExecuteNonQuery();

                                    // set target card to primary
                                    command2.CommandText = "Update MemberCard " +
                                                           "set IsPrimary = 1 " +
                                                           "where FPNumber = '" + targetCard + "'";
                                    command2.ExecuteNonQuery();

                                    //Set target member email status to good (7) and update date
                                    command2.CommandText = "Update MemberInformationMain " +
                                                           "set EmailStatus = 7, UpdateDatetime = getDate() " +
                                                           "where MemberId = " + targetMemberId;
                                    command2.ExecuteNonQuery();

                                    //Set orig email status to empty (0), update date, email address to '', and isdeleted
                                    command2.CommandText = "Update MemberInformationMain " +
                                                           "set EmailStatus = 0, EmailAddress = '', UpdateDatetime = getDate(), IsDeleted = 1 " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update activity on remote
                                    command2.CommandText = "Update Activity " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update manualedits on remote
                                    command2.CommandText = "Update ManualEdits " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update reservations on remote
                                    command2.CommandText = "Update Reservations " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update Redemptions on remote
                                    command2.CommandText = "Update Redemptions " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update Referrals on remote
                                    command2.CommandText = "Update Referral " +
                                                           "set MemberId = " + targetMemberId + " " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    //Update Beginning Points on remote
                                    command2.CommandText = "Update MemberBeginningBalance " +
                                                           "set BeginningPoints = " + newBeginningBalance + " " +
                                                           "where MemberId = " + targetMemberId;
                                    command2.ExecuteNonQuery();

                                    command2.CommandText = "Update MemberBeginningBalance " +
                                                           "set BeginningPoints = 0 " +
                                                           "where MemberId = " + sourceMemberId;
                                    command2.ExecuteNonQuery();

                                    // Attempt to commit the transaction.
                                    transaction1.Commit();
                                    transaction2.Commit();

                                    //The transactions have been committed so we can call the stored procedure for visit tracking
                                    //Call stored procedure to run the visit tracking on this target member
                                    thisADO.UpdateMemberVisitTracking(Convert.ToInt32(targetMemberId), false);

                                    //add notes and log
                                    strSQL = "Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                            "values(" + targetMemberId + ", '" + targetCard + " had " +  sourceCard + " combined with it on ' + GETDATE() + ' by " +
                                            cardsToCombine.CombinedBy + "  . Source members email address was " + sourceEmailAddress + "', GETDATE(), '', GETDATE(), -1)";
                                    thisADO.updateOrInsert(strSQL, true);

                                    strSQL = "Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                            "values(" + sourceMemberId + ", '" + sourceCard + " was combined into " + targetCard + "  on ' + GETDATE() + ' by " +
                                            cardsToCombine.CombinedBy + "  . Source members email address was " + sourceEmailAddress + "', GETDATE(), '', GETDATE(), -1)";
                                    thisADO.updateOrInsert(strSQL, true);

                                    strSQL = "Insert into changeLog (changeUser, changeDate, ChangeId, changeValOld, changeValNew, changeTable, " +
                                                "changeNote, CreateDatetime, CreateUserId) " +
                                                "values('" + cardsToCombine.CombinedBy + "', GETDATE(), " + targetMemberId + ", '" + sourceCard + "', '" + targetCard + "', 'MemberInformationMain', '" +
                                                sourceCard + " was combined into " + targetCard + "  . Source members email address was " + sourceEmailAddress +"', GETDATE(), -1)";
                                    thisADO.updateOrInsert(strSQL, false);
                                    return "Cards Combined";
                                }
                                catch (Exception ex)
                                {
                                    transaction1.Rollback();
                                    transaction2.Rollback();
                                    return "Error - " + ex.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction1.Rollback();
                        return "Error - " + ex.ToString();
                    }

                }
            }
        }
    }
}
