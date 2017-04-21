using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version390
{
    public static class Utilities
    {
        #region Public Methods

        #region Collection

        public static void SortById(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(CompareId);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByTitleAscending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(CompareSortTitleAscending);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByTitleDescending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(CompareSortTitleDescending);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByPurchaseDateAscending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(ComparePurchaseDateAscending);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByPurchaseDateDescending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(ComparePurchaseDateDescending);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByCollectionNumberAscending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(CompareCollectionNumberAscending);

                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByCollectionNumberDescending(Collection collection)
        {
            if (collection.DVDList?.Length > 0)
            {
                List<DVD> list = new List<DVD>(collection.DVDList);

                list.Sort(CompareCollectionNumberDescending);

                collection.DVDList = list.ToArray();
            }
        }
        #endregion

        #region Clipboard

        public static Boolean TryGetCastInformationFromClipboard(out CastInformation castInformation)
        {
            try
            {
                String xml = Clipboard.GetText();

                xml = xml.Replace("\"False\"", "\"false\"").Replace("\"True\"", "\"true\"");

                castInformation = Serializer<CastInformation>.FromString(xml, CastInformation.DefaultEncoding);

                return (true);
            }
            catch
            {
                castInformation = null;

                return (false);
            }
        }

        public static Boolean TryGetCrewInformationFromClipboard(out CrewInformation crewInformation)
        {
            try
            {
                String xml = Clipboard.GetText();

                xml = xml.Replace("\"False\"", "\"false\"").Replace("\"True\"", "\"true\"");

                crewInformation = Serializer<CrewInformation>.FromString(xml, CrewInformation.DefaultEncoding);

                return (true);
            }
            catch
            {
                crewInformation = null;
                return (false);
            }
        }

        public static String CopyCastInformationToClipboard(CastInformation castInformation
            , Boolean silent = false)
        {
            String xml = Serializer<CastInformation>.ToString(castInformation, CastInformation.DefaultEncoding);

            if (silent == false)
            {
                try
                {
                    Clipboard.SetDataObject(xml, true, 4, 250);
                }
                catch
                { }
            }

            return (xml);
        }

        public static String CopyCrewInformationToClipboard(CrewInformation crewInformation
            , Boolean silent = false)
        {
            crewInformation = CrewSorter.GetSortedCrew(crewInformation);

            String xml = Serializer<CrewInformation>.ToString(crewInformation, CrewInformation.DefaultEncoding);

            if (silent == false)
            {
                try
                {
                    Clipboard.SetDataObject(xml, true, 4, 250);
                }
                catch
                { }
            }

            return (xml);
        }

        #endregion

        #region CollectionTree

        public static CollectionTree GetCollectionTree(Collection collection)
        {
            List<DVDNode> list = new List<DVDNode>();

            if (collection.DVDList?.Length > 0)
            {
                Dictionary<String, DVD> dict = new Dictionary<String, DVD>(collection.DVDList.Length);

                foreach (DVD dvd in collection.DVDList)
                {
                    dict.Add(dvd.ID, dvd);
                }

                foreach (DVD dvd in collection.DVDList)
                {
                    if (dict.ContainsKey(dvd.ID))
                    {
                        if ((dvd.BoxSet == null) || (String.IsNullOrEmpty(dvd.BoxSet.Parent)))
                        {
                            //Node has no parent
                            AddDVDNode(dict, list, dvd);
                        }
                        else if (dict.ContainsKey(dvd.BoxSet.Parent) == false)
                        {
                            //Parent does not exist in collection: treat as root element
                            AddDVDNode(dict, list, dvd);
                        }
                    }
                }
            }

            CollectionTree tree = new CollectionTree();

            tree.DVDList = list;

            return (tree);
        }

        private static void AddDVDNode(Dictionary<String, DVD> dict
            , List<DVDNode> parentList
            , DVD dvd)
        {
            DVDNode node = new DVDNode();

            node.DVD = dvd;

            if (dvd.BoxSet.ContentList != null)
            {
                List<DVDNode> childList = new List<DVDNode>(dvd.BoxSet.ContentList.Length);

                foreach (String id in dvd.BoxSet.ContentList)
                {
                    if (dict.ContainsKey(id))
                    {
                        AddDVDNode(dict, childList, dict[id]);
                    }
                }

                node.ChildrenList = childList;
            }
            else
            {
                node.ChildrenList = new List<DVDNode>(0);
            }

            parentList.Add(node);

            dict.Remove(dvd.ID);
        }

        public static void SortById(CollectionTree tree
            , Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortById(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortById(List<DVDNode> nodeList
            , Boolean sortChildNodes)
        {
            if (nodeList?.Count > 0)
            {
                nodeList.Sort(CompareId);

                if (sortChildNodes)
                {
                    foreach (DVDNode node in nodeList)
                    {
                        SortById(node.ChildrenList, sortChildNodes);
                    }
                }
            }
        }

        public static void SortByTitleAscending(CollectionTree tree
            , Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortByTitleAscending(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortByTitleAscending(List<DVDNode> nodeList
            , Boolean sortChildNodes)
        {
            if (nodeList?.Count > 0)
            {
                nodeList.Sort(CompareSortTitleAscending);

                if (sortChildNodes)
                {
                    foreach (DVDNode node in nodeList)
                    {
                        SortByTitleAscending(node.ChildrenList, sortChildNodes);
                    }
                }
            }
        }

        public static void SortByTitleDescending(CollectionTree tree
            , Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortByTitleDescending(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortByTitleDescending(List<DVDNode> nodeList
            , Boolean sortChildNodes)
        {
            if (nodeList?.Count > 0)
            {
                nodeList.Sort(CompareSortTitleDescending);

                if (sortChildNodes)
                {
                    foreach (DVDNode node in nodeList)
                    {
                        SortByTitleDescending(node.ChildrenList, sortChildNodes);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #region Collection

        private static Int32 CompareId(DVD left
            , DVD right)
        {
            if (left.ID == null)
            {
                if (right.ID == null)
                {
                    return (0);
                }
                else
                {
                    return (-1);
                }
            }
            else if (right.ID == null)
            {
                return (1);
            }
            else
            {
                return (left.ID.CompareTo(right.ID));
            }
        }

        private static Int32 CompareSortTitleAscending(DVD left
            , DVD right)
            => (CompareSortTitle(left, right));

        private static Int32 CompareSortTitleDescending(DVD left
            , DVD right)
            => (CompareSortTitle(right, left));

        internal static Int32 CompareSortTitle(DVD left
            , DVD right)
        {
            if (left.SortTitle == null)
            {
                if (right.SortTitle == null)
                {
                    return (0);
                }
                else
                {
                    return (-1);
                }
            }
            else if (right.SortTitle == null)
            {
                return (1);
            }
            else
            {
                Int32 compare = left.SortTitle.CompareTo(right.SortTitle);

                if (compare == 0)
                {
                    compare = CompareId(left, right);
                }

                return (compare);
            }
        }

        private static Int32 CompareCollectionNumberAscending(DVD left
            , DVD right)
            => (CompareCollectionNumber(left, right));

        private static Int32 CompareCollectionNumberDescending(DVD left
            , DVD right)
            => (CompareCollectionNumber(right, left));

        private static Int32 CompareCollectionNumber(DVD left
            , DVD right)
        {
            if (left.CollectionNumber == null)
            {
                if (right.CollectionNumber == null)
                {
                    return (CompareSortTitle(left, right));
                }
                else
                {
                    return (-1);
                }
            }
            else if (right.CollectionNumber == null)
            {
                return (1);
            }
            else
            {
                Int32 compare = left.CollectionNumber.CompareTo(right.CollectionNumber);

                if (compare == 0)
                {
                    compare = CompareSortTitle(left, right);
                }

                return (compare);
            }
        }

        private static Int32 ComparePurchaseDateAscending(DVD left
            , DVD right)
            => (ComparePurchaseDate(left, right));

        private static Int32 ComparePurchaseDateDescending(DVD left
            , DVD right)
            => (ComparePurchaseDate(right, left));

        private static Int32 ComparePurchaseDate(DVD left
            , DVD right)
        {
            if ((left.PurchaseInfo == null) || (left.PurchaseInfo.DateSpecified == false))
            {
                if ((right.PurchaseInfo == null) || (right.PurchaseInfo.DateSpecified == false))
                {
                    return (CompareSortTitle(left, right));
                }
                else
                {
                    return (-1);
                }
            }
            else if ((right.PurchaseInfo == null) || (right.PurchaseInfo.DateSpecified == false))
            {
                return (1);
            }
            else
            {
                Int32 compare = left.PurchaseInfo.Date.CompareTo(right.PurchaseInfo.Date);

                if (compare == 0)
                {
                    compare = CompareSortTitle(left, right);
                }

                return (compare);
            }
        }

        #endregion

        #region CollectionTree

        private static Int32 CompareSortTitleAscending(DVDNode left
            , DVDNode right)
            => (CompareSortTitle(left, right));

        private static Int32 CompareSortTitleDescending(DVDNode left
            , DVDNode right)
            => (CompareSortTitle(right, left));

        private static Int32 CompareSortTitle(DVDNode left
            , DVDNode right)
        {
            if ((left.DVD == null) || (left.DVD.SortTitle == null))
            {
                if ((right.DVD == null) || (right.DVD.SortTitle == null))
                {
                    return (0);
                }
                else
                {
                    return (-1);
                }
            }
            else if ((right.DVD == null) || (right.DVD.SortTitle == null))
            {
                return (1);
            }
            else
            {
                return (left.DVD.SortTitle.CompareTo(right.DVD.SortTitle));
            }
        }

        private static Int32 CompareId(DVDNode left, DVDNode right)
        {
            if ((left.DVD == null) || (left.DVD.ID == null))
            {
                if ((right.DVD == null) || (right.DVD.ID == null))
                {
                    return (0);
                }
                else
                {
                    return (-1);
                }
            }
            else if ((right.DVD == null) || (right.DVD.ID == null))
            {
                return (1);
            }
            else
            {
                return (left.DVD.ID.CompareTo(right.DVD.ID));
            }
        }

        #endregion

        #endregion
    }
}