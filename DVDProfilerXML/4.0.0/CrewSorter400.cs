using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version400
{
    public static class CrewSorter
    {
        private class CrewComparer : IComparable<CrewComparer>
        {
            private int EpisodeId { get; set; }

            private int OriginalOrderId { get; set; }

            private CrewMember CrewMember { get; set; }

            private CrewDivider CrewDivider { get; set; }

            internal object CrewEntry => (CrewMember != null) ? (object)CrewMember : CrewDivider;

            private CrewComparer(int episodeId, int originalOrderId)
            {
                EpisodeId = episodeId;
                OriginalOrderId = originalOrderId;
            }

            internal CrewComparer(int episodeId, int originalOrderId, CrewMember crewMember) : this(episodeId, originalOrderId)
            {
                CrewMember = crewMember;
            }

            internal CrewComparer(int episodeId, int originalOrderId, CrewDivider crewDivider) : this(episodeId, originalOrderId)
            {
                CrewDivider = crewDivider;
            }

            public int CompareTo(CrewComparer other)
            {
                if (other == null)
                {
                    return 1;
                }

                var compare = EpisodeId.CompareTo(other.EpisodeId);

                if (compare != 0)
                {
                    return compare;
                }

                compare = GetCompareValue(CrewEntry, other.CrewEntry);

                if (compare != 0)
                {
                    return compare;
                }

                return OriginalOrderId.CompareTo(other.OriginalOrderId);
            }

            private static int GetCompareValue(object left, object right)
            {
                var compareLeft = GetCompareValue(left);

                var compareRight = GetCompareValue(right);

                return compareLeft.CompareTo(compareRight);
            }

            private static int GetCompareValue(object crewEntry)
            {
                var crewDivider = crewEntry as CrewDivider;

                int compare;
                if (crewDivider != null)
                {
                    switch (crewDivider.Type)
                    {
                        case (DividerType.Episode):
                            {
                                compare = -1;

                                break;
                            }
                        default:
                            {
                                compare = GetCompareValue(crewDivider.CreditType);

                                break;
                            }
                    }
                }
                else
                {
                    var crewMember = crewEntry as CrewMember;

                    if (crewMember != null)
                    {
                        compare = GetCompareValue(crewMember.CreditType);
                    }
                    else
                    {
                        Debug.Fail(string.Format("Unknown object type {0}", crewEntry));

                        compare = -2;
                    }
                }

                return compare;
            }

            private static int GetCompareValue(string creditType)
            {
                switch (creditType)
                {
                    case ("Direction"):
                        {
                            return 1;
                        }
                    case ("Writing"):
                        {
                            return 2;
                        }
                    case ("Production"):
                        {
                            return 3;
                        }
                    case ("Cinematography"):
                        {
                            return 4;
                        }
                    case ("Film Editing"):
                        {
                            return 5;
                        }
                    case ("Music"):
                        {
                            return 6;
                        }
                    case ("Sound"):
                        {
                            return 7;
                        }
                    case ("Art"):
                        {
                            return 8;
                        }
                    case ("Other"):
                        {
                            return 9;
                        }
                    default:
                        {
                            Debug.Fail(string.Format("Unknown Credit Type '{0}'", creditType));

                            return 0;
                        }
                }
            }
        }

        public static CrewInformation GetSortedCrew(CrewInformation unsortedCrew)
        {
            if ((unsortedCrew?.CrewList?.Length > 0) == false)
            {
                return unsortedCrew;
            }

            var sortedCrew = new CrewInformation()
            {
                Title = unsortedCrew.Title,
            };

            var sortedList = new List<CrewComparer>(unsortedCrew.CrewList.Length);

            var currentEpisodeId = 0;

            var originalOrderId = 0;

            foreach (var crewEntry in unsortedCrew.CrewList)
            {
                if (crewEntry is CrewDivider divider)
                {
                    if (divider.Type == DividerType.Episode)
                    {
                        currentEpisodeId++;
                    }

                    sortedList.Add(new CrewComparer(currentEpisodeId, originalOrderId, divider));
                }
                else
                {
                    sortedList.Add(new CrewComparer(currentEpisodeId, originalOrderId, crewEntry as CrewMember));
                }

                originalOrderId++;
            }

            sortedList.Sort();

            sortedCrew.CrewList = sortedList.ConvertAll(sortedEntry => sortedEntry.CrewEntry).ToArray();

            return sortedCrew;
        }
    }
}