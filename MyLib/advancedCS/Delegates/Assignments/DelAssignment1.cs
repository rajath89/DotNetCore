using MyLib.advancedCS.Delegates.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyLib.advancedCS.Delegates.Assignments
{
    delegate void ApproveClaimDelegate(ref Claim claim);
    public class Claim
    {
        public Claim() { }

        public Claim(int claimId,int insuranceId,int noOfProofs)
        {
            this.ClaimId = claimId;
            this.InsuranceId = insuranceId;
            this.NoOfProofs = noOfProofs;
        }

        public int ClaimId { get; set; }
        public string CommentBM { get; set;}

        public string CommentUW { get; set;}

        public int InsuranceId { get; set;}

        public int NoOfProofs { get; set; }

        public void ApproveClaimUW(ref Claim claim)
        {
            if (claim.NoOfProofs >= 3)
                claim.CommentUW = "Approved";
            else
                claim.CommentUW = "Rejected";
        }

        public void ApproveClaimBM(ref Claim claim)
        {
            if (claim.CommentUW == "Approved")
                claim.CommentBM = "Approved";
            else if (claim.CommentUW == "Rejected")
                claim.CommentBM = "Rejected";
            else
                claim.CommentBM = "NA";
        }
    }

    public class Assistant
    {
        public Assistant()
        {
            
        }

        public void ApproveClaim(string role, ref Claim claim)
        {
            ApproveClaimDelegate approveClaimDelegate;

            if (role == "UnderWriter")
                approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimUW);
            else if (role == "BankManager")
                approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimBM);
            else if (role == "InsuranceManager")
                approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimUW) + new ApproveClaimDelegate(claim.ApproveClaimBM);
            else
                return; // Invalid role, do nothing.

            approveClaimDelegate(ref claim);
        }
    }

    public class DelAssignment1
    {
        public void Main()
        {
            // Test data
            Claim claim1 = new Claim(1, 101, 4);
            Claim claim2 = new Claim(2, 102, 2);
            Claim claim3 = new Claim(3, 103, 5);

            Assistant assistant = new Assistant();

            assistant.ApproveClaim("UnderWriter", ref claim1);
            assistant.ApproveClaim("BankManager", ref claim1);

            assistant.ApproveClaim("UnderWriter", ref claim2);
            assistant.ApproveClaim("BankManager", ref claim2);

            assistant.ApproveClaim("UnderWriter", ref claim3);
            assistant.ApproveClaim("BankManager", ref claim3);

            Console.WriteLine($"Claim 1: CommentUW - {claim1.CommentUW}, CommentBM - {claim1.CommentBM}");
            Console.WriteLine($"Claim 2: CommentUW - {claim2.CommentUW}, CommentBM - {claim2.CommentBM}");
            Console.WriteLine($"Claim 3: CommentUW - {claim3.CommentUW}, CommentBM - {claim3.CommentBM}");
        }
    }
}



 
