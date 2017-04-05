using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

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

                //Set target card as primary
                thisADO.updateOrInsert("Update MemberCard set IsPrimary = 1 where FPNumber = " + cardsToCombine.TargetCard, true);
                //Set memberId of origin memberCard to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update MemberCard set MemberId = " + targetMemberId + ", IsPrimary = 0 where FPNumber = " + cardsToCombine.OriginCard, true);


                //set email status and dateupdated for both member accounts and set deleted for origin
                thisADO.updateOrInsert("Update MemberInformationMain set EmailStatus = 7, UpdateDatetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' where MemberId = " + targetMemberId, true);
                thisADO.updateOrInsert("Update MemberInformationMain set EmailStatus = 0, EmailAddress = '', UpdateDatetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' where MemberId = " + originMemberId, true);
                thisADO.updateOrInsert("Update MemberInformationMain set IsDeleted = 1 where MemberId = " + originMemberId, true);

                //Set memberId of origin activity to target MemberId and do on both remote and local since it does not sync
                thisADO.updateOrInsert("Update Activity set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, false);
                thisADO.updateOrInsert("Update Activity set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Set memberId of origin Manual Edits to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update ManualEdits set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);
                
                //Set memberId of origin Reservations to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update Reservations set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

                //Set memberId of origin Redemptions to target MemberId this will get synced from remote
                thisADO.updateOrInsert("Update Redemptions set MemberId = " + targetMemberId + " where MemberId = " + originMemberId, true);

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

                //Delete all marketing visit tracking for target account
                thisADO.updateOrInsert("Delete from MemberVisitTracking where MemberId = " + targetMemberId, false);

                //Set IsCombined = 1 in marketing visit tracking for origin MemberId
                thisADO.updateOrInsert("Update MemberVisitTracking set IsCombined = 1 where MemberId = " + originMemberId, false);


                //Call stored procedure to run the visit tracking on this target members ID on remote it gets synced
                thisADO.UpdateMemberVisitTracking(targetMemberId, false); 

                //Add note to target member account
                thisADO.updateOrInsert("Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                       "values (" + targetMemberId + ",'MemberId " + cardsToCombine.OriginCard + " was combined into " + cardsToCombine.TargetCard + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + "'," +
                                       " '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', '" + cardsToCombine.CombinedBy + "', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', -1)", true);
                
                //Add note to origin member account
                thisADO.updateOrInsert("Insert into MemberNotes (MemberId, Note, Date, SubmittedBy, CreateDateTime, CreateUserId) " +
                                       "values (" + originMemberId + ",'MemberId " + cardsToCombine.OriginCard + " was combined into " + cardsToCombine.TargetCard + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + "'," +
                                       " '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', '" + cardsToCombine.CombinedBy + "', '" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff") + "', -1)", true);

                //Add note to target changelog
                string strInsertLogSQL = "Insert into changeLog " + "(changeUser, changeDate, changeID, changeValOld, changeValNew, changeTable, changeNote, changeBatch, CreateUserId) " +
                     "Values ('" + cardsToCombine.CombinedBy + "', '" + DateTime.Now + "', '" + originMemberId + "', '" + originMemberId + "', '" + targetMemberId + "', '" +
                              "" + "', '" + "MemberId " + originMemberId + " was combined with " + targetMemberId + " on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " by " + cardsToCombine.CombinedBy + "', 0, -1)";
                
                thisADO.updateOrInsert(strInsertLogSQL, true);

                return "Members cards have been combined!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
    }
}
