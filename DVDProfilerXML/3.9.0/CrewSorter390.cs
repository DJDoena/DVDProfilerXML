using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version390
{
    public static class CrewSorter
    {
        private class CrewComparer : IComparable<CrewComparer>
        {
            private Int32 EpisodeId { get; set; }

            private Int32 OriginalOrderId { get; set; }

            private CrewMember CrewMember { get; set; }

            private CrewDivider CrewDivider { get; set; }

            internal Object CrewEntry
                => ((CrewMember != null) ? (Object)CrewMember : CrewDivider);

            private CrewComparer(Int32 episodeId
                , Int32 originalOrderId)
            {
                EpisodeId = episodeId;
                OriginalOrderId = originalOrderId;
            }

            internal CrewComparer(Int32 episodeId
                , Int32 originalOrderId
                , CrewMember crewMember)
                : this(episodeId, originalOrderId)
            {
                CrewMember = crewMember;
            }

            internal CrewComparer(Int32 episodeId
                , Int32 originalOrderId
                , CrewDivider crewDivider)
                : this(episodeId, originalOrderId)
            {
                CrewDivider = crewDivider;
            }

            public Int32 CompareTo(CrewComparer other)
            {
                if (other == null)
                {
                    return (1);
                }

                Int32 compare = EpisodeId.CompareTo(other.EpisodeId);

                if (compare != 0)
                {
                    return (compare);
                }

                compare = GetCompareValue(CrewEntry, other.CrewEntry);

                if (compare != 0)
                {
                    return (compare);
                }

                return (OriginalOrderId.CompareTo(other.OriginalOrderId));
            }

            private static Int32 GetCompareValue(Object left
                , Object right)
            {
                Int32 compareLeft = GetCompareValue(left);

                Int32 compareRight = GetCompareValue(right);

                return (compareLeft.CompareTo(compareRight));
            }

            private static Int32 GetCompareValue(Object crewEntry)
            {
                CrewDivider crewDivider = crewEntry as CrewDivider;

                Int32 compare;
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
                    CrewMember crewMember = crewEntry as CrewMember;

                    if (crewMember != null)
                    {
                        compare = GetCompareValue(crewMember.CreditType);
                    }
                    else
                    {
                        Debug.Fail(String.Format("Unknown Object type {0}", crewEntry));

                        compare = -2;
                    }
                }

                return (compare);
            }

            private static Int32 GetCompareValue(String creditType)
            {
                switch (creditType)
                {
                    case ("Direction"):
                        {
                            return (1);
                        }
                    case ("Writing"):
                        {
                            return (2);
                        }
                    case ("Production"):
                        {
                            return (3);
                        }
                    case ("Cinematography"):
                        {
                            return (4);
                        }
                    case ("Film Editing"):
                        {
                            return (5);
                        }
                    case ("Music"):
                        {
                            return (6);
                        }
                    case ("Sound"):
                        {
                            return (7);
                        }
                    case ("Art"):
                        {
                            return (8);
                        }
                    case ("Other"):
                        {
                            return (9);
                        }
                    default:
                        {
                            Debug.Fail(String.Format("Unknown Credit Type '{0}'", creditType));

                            return (0);
                        }
                }
            }
        }

        public static CrewInformation GetSortedCrew(CrewInformation unsortedCrew)
        {
            if ((unsortedCrew?.CrewList?.Length > 0) == false)
            {
                return (unsortedCrew);
            }

            CrewInformation sortedCrew = new CrewInformation();

            sortedCrew.Title = unsortedCrew.Title;

            List<CrewComparer> sortedList = new List<CrewComparer>(unsortedCrew.CrewList.Length);

            Int32 currentEpisodeId = 0;

            Int32 originalOrderId = 0;

            foreach (Object crewEntry in unsortedCrew.CrewList)
            {
                CrewDivider divider = crewEntry as CrewDivider;

                if (divider != null)
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

            sortedCrew.CrewList = (sortedList.ConvertAll<Object>(sortedEntry => sortedEntry.CrewEntry)).ToArray();

            return (sortedCrew);
        }
    }
}