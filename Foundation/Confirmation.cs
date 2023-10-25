using System;

namespace Swopblock;

public partial record Confirmation
{
    public static Confirmation SimulateHistory(int CandidateCountAverage, int CandidateCountDeviation)
    {
        return null;
    }

    public static Confirmation LoadHistory
    (
        int CandidateCount,

        int AddressCount,

        int TransferCount
    )
    {
        var candidates = new Candidate[CandidateCount];

        for (int i = 0; i < CandidateCount; i++)
        {
            candidates[i] = Candidate.LoadHistory
                (
                    AddressCount,

                    TransferCount
                );
        }

        //var confirmation = new Confirmation(candidates);

        //return confirmation;

        return null;
    }

}

