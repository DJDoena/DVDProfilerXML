//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version390
//{
//    public sealed class CollectionTree
//    {
//        public List<DVDNode> DVDList;

//        public override String ToString()
//        {
//            StringBuilder sb = new StringBuilder();

//            sb.Append("Count: ");

//            if (DVDList != null)
//            {
//                sb.Append(DVDList.Count);
//            }
//            else
//            {
//                sb.Append("none");
//            }

//            return (sb.ToString());
//        }
//    }

//    public sealed class DVDNode
//    {
//        public DVD DVD;

//        public List<DVDNode> ChildrenList;

//        public override String ToString()
//            => ((DVD != null) ? DVD.ToString() : base.ToString());
//    }
//}