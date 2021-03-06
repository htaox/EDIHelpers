using System.Collections.Generic;
using EDIHelpers.Attributes;
using EDIHelpers.Dictionary;
using EDIHelpers.Dictionary.Segments;
using EDIDocuments.ANSI.X12_277;

namespace EDIDocuments.ANSI
{

    //Since we do not have a selector for the Groups, the file must contian all the 
    //same group types.
    public class EDI277: EDIBase
    {
        public EDI277()
        {
        }
        public ISASeg ISA { get; set; }
        [EDILoop("GS")]
        public List<GS277> GSLoop { get; set; }
        public IEASeg IEA { get; set; }

        /// <summary>
        /// Designed to set the counts for IEA, GE, and SE segments by reading non null objects in the SE area.
        /// Sets all ST-SE control numbers to 0001 to start with per GS group and then counts forward.
        /// </summary>
        public void SetCounts()
        {
            IEA.IEA01_GroupCount = GSLoop.Count;
            foreach (var grp in GSLoop)
            {
                grp.GE.GE01_TransactionCount = grp.STLoops.Count;
                int stCnt = 0;
                for (int i = 0; i < grp.STLoops.Count; i++)
                {
                    var stl = grp.STLoops[i];
                    stl.ST.ST02ControlNumber = (stCnt++).ToString().PadLeft(4, '0');
                    stl.SE.SE02_ControlNumber = stl.ST.ST02ControlNumber;
                    stl.SE.SE01_SegmentCount = stl.GetSegmentCount();
                    stl.EnsureCounts();
                }
            }
        }
    }
}
