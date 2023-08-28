using System.Collections.Generic;
using System.Text;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version400
{
    public sealed class CollectionTree
    {
        public List<DVDNode> DVDList;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Count: ");

            if (DVDList != null)
            {
                sb.Append(DVDList.Count);
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString();
        }
    }

    public sealed class DVDNode
    {
        public DVD DVD;

        public List<DVDNode> ChildrenList;

        public override string ToString() => (DVD != null) ? DVD.ToString() : base.ToString();
    }
}