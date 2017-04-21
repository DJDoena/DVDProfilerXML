using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version381
{
    public static class Utilities
    {
        #region Public Methods
        #region Collection
        public static void SortById(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(CompareId));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByTitleAscending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(CompareSortTitleAscending));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByTitleDescending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(CompareSortTitleDescending));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByPurchaseDateAscending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(ComparePurchaseDateAscending));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByPurchaseDateDescending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(ComparePurchaseDateDescending));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByCollectionNumberAscending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(CompareCollectionNumberAscending));
                collection.DVDList = list.ToArray();
            }
        }

        public static void SortByCollectionNumberDescending(Collection collection)
        {
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                List<DVD> list;

                list = new List<DVD>(collection.DVDList);
                list.Sort(new Comparison<DVD>(CompareCollectionNumberDescending));
                collection.DVDList = list.ToArray();
            }
        }
        #endregion

        #region Clipboard
        public static Boolean TryGetCastInformationFromClipboard(out CastInformation castInformation)
        {
            try
            {
                String xml;

                xml = Clipboard.GetText();
                xml = xml.Replace("\"False\"", "\"false\"").Replace("\"True\"", "\"true\"");
                using (TextReader tr = new StringReader(xml))
                {
                    castInformation = (CastInformation)(CastInformation.XmlSerializer.Deserialize(tr));
                    return (true);
                }
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
                String xml;

                xml = Clipboard.GetText();
                xml = xml.Replace("\"False\"", "\"false\"").Replace("\"True\"", "\"true\"");
                using (TextReader tr = new StringReader(xml))
                {
                    crewInformation = (CrewInformation)(CrewInformation.XmlSerializer.Deserialize(tr));
                    return (true);
                }
            }
            catch
            {
                crewInformation = null;
                return (false);
            }
        }

        public static void CopyCastInformationToClipboard(CastInformation castInformation)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms, Encoding.GetEncoding("iso-8859-1")))
                {
                    Byte[] buffer;
                    String xml;

                    CastInformation.XmlSerializer.Serialize(sw, castInformation);
                    ms.Seek(0, SeekOrigin.Begin);
                    buffer = new Byte[ms.Length];
                    ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                    xml = Encoding.GetEncoding("iso-8859-1").GetString(buffer);
                    Clipboard.SetDataObject(xml, true, 4, 250);
                }
            }
        }

        public static void CopyCrewInformationToClipboard(CrewInformation crewInformation)
        {
            crewInformation = CrewSorter.GetSortedCrew(crewInformation);
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms, Encoding.GetEncoding("iso-8859-1")))
                {
                    Byte[] buffer;
                    String xml;

                    CrewInformation.XmlSerializer.Serialize(sw, crewInformation);
                    ms.Seek(0, SeekOrigin.Begin);
                    buffer = new Byte[ms.Length];
                    ms.Read(buffer, 0, Convert.ToInt32(ms.Length));
                    xml = Encoding.GetEncoding("iso-8859-1").GetString(buffer);
                    Clipboard.SetDataObject(xml, true, 4, 250);
                }
            }
        }
        #endregion

        #region CollectionTree
        public static CollectionTree GetCollectionTree(Collection collection)
        {
            CollectionTree tree;
            Dictionary<String, DVD> dict;
            List<DVDNode> list;

            list = new List<DVDNode>();
            if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
            {
                dict = new Dictionary<string, DVD>(collection.DVDList.Length);
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
            tree = new CollectionTree();
            tree.DVDList = list;
            return (tree);
        }

        private static void AddDVDNode(Dictionary<String, DVD> dict, List<DVDNode> parentList, DVD dvd)
        {
            DVDNode node;

            node = new DVDNode();
            node.DVD = dvd;
            if (dvd.BoxSet.ContentList != null)
            {
                List<DVDNode> childList;

                childList = new List<DVDNode>(dvd.BoxSet.ContentList.Length);
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

        public static void SortById(CollectionTree tree, Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortById(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortById(List<DVDNode> nodeList, Boolean sortChildNodes)
        {
            if ((nodeList != null) && (nodeList.Count > 0))
            {
                nodeList.Sort(new Comparison<DVDNode>(CompareId));
                if (sortChildNodes)
                {
                    foreach (DVDNode node in nodeList)
                    {
                        SortById(node.ChildrenList, sortChildNodes);
                    }
                }
            }
        }

        public static void SortByTitleAscending(CollectionTree tree, Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortByTitleAscending(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortByTitleAscending(List<DVDNode> nodeList, Boolean sortChildNodes)
        {
            if ((nodeList != null) && (nodeList.Count > 0))
            {
                nodeList.Sort(new Comparison<DVDNode>(CompareSortTitleAscending));
                if (sortChildNodes)
                {
                    foreach (DVDNode node in nodeList)
                    {
                        SortByTitleAscending(node.ChildrenList, sortChildNodes);
                    }
                }
            }
        }

        public static void SortByTitleDescending(CollectionTree tree, Boolean sortChildNodes)
        {
            if (tree != null)
            {
                SortByTitleDescending(tree.DVDList, sortChildNodes);
            }
        }

        public static void SortByTitleDescending(List<DVDNode> nodeList, Boolean sortChildNodes)
        {
            if ((nodeList != null) && (nodeList.Count > 0))
            {
                nodeList.Sort(new Comparison<DVDNode>(CompareSortTitleDescending));
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
        private static Int32 CompareId(DVD left, DVD right)
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

        private static Int32 CompareSortTitleAscending(DVD left, DVD right)
        {
            return (CompareSortTitle(left, right));
        }

        private static Int32 CompareSortTitleDescending(DVD left, DVD right)
        {
            return (CompareSortTitle(right, left));
        }

        internal static Int32 CompareSortTitle(DVD left, DVD right)
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
                Int32 compare;

                compare = left.SortTitle.CompareTo(right.SortTitle);
                if (compare == 0)
                {
                    compare = CompareId(left, right);
                }
                return (compare);
            }
        }

        private static Int32 CompareCollectionNumberAscending(DVD left, DVD right)
        {
            return (CompareCollectionNumber(left, right));
        }

        private static Int32 CompareCollectionNumberDescending(DVD left, DVD right)
        {
            return (CompareCollectionNumber(right, left));
        }

        private static Int32 CompareCollectionNumber(DVD left, DVD right)
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
                Int32 compare;

                compare = left.CollectionNumber.CompareTo(right.CollectionNumber);
                if (compare == 0)
                {
                    compare = CompareSortTitle(left, right);
                }
                return (compare);
            }
        }

        private static Int32 ComparePurchaseDateAscending(DVD left, DVD right)
        {
            return (ComparePurchaseDate(left, right));
        }

        private static Int32 ComparePurchaseDateDescending(DVD left, DVD right)
        {
            return (ComparePurchaseDate(right, left));
        }

        private static Int32 ComparePurchaseDate(DVD left, DVD right)
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
                Int32 compare;

                compare = left.PurchaseInfo.Date.CompareTo(right.PurchaseInfo.Date);
                if (compare == 0)
                {
                    compare = CompareSortTitle(left, right);
                }
                return (compare);
            }
        }
        #endregion

        #region CollectionTree
        private static Int32 CompareSortTitleAscending(DVDNode left, DVDNode right)
        {
            return (CompareSortTitle(left, right));
        }

        private static Int32 CompareSortTitleDescending(DVDNode left, DVDNode right)
        {
            return (CompareSortTitle(right, left));
        }

        private static Int32 CompareSortTitle(DVDNode left, DVDNode right)
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