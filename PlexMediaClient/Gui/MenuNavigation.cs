using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using System.Web;

namespace PlexMediaClient.Gui {
    public static class MenuNavigation {
        //private static BackgroundWorker NewItemFetcher { get; set; }
        private static Stack<MediaContainer> History { get; set; }

        public static event OnErrorOccuredEventHandler OnErrorOccured;
        public delegate void OnErrorOccuredEventHandler(Exception e);
        public static event OnItemsFetchedEventHandler OnItemsFetched;
        public delegate void OnItemsFetchedEventHandler(List<IMenuItem> fetchedItems);
        public static event OnItemsFetchProgressEventHandler OnItemsFetchProgress;
        public delegate void OnItemsFetchProgressEventHandler(int progress);

        static MenuNavigation() {            
            //NewItemFetcher = new BackgroundWorker();
            //NewItemFetcher.DoWork += new DoWorkEventHandler(NewItemFetcher_DoWork);
            //NewItemFetcher.ProgressChanged += new ProgressChangedEventHandler(NewItemFetcher_ProgressChanged);
            //NewItemFetcher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(NewItemFetcher_RunWorkerCompleted);
            //NewItemFetcher.WorkerReportsProgress = true;
            //NewItemFetcher.WorkerSupportsCancellation = true;
            PlexInterface.OnPlexError += new PlexInterface.OnPlexErrorEventHandler(PlexInterface_OnPlexError);
            PlexInterface.OnPlexConnected += new PlexInterface.OnPlexConnectedEventHandler(PlexInterface_OnPlexConnected);
        }

        static void PlexInterface_OnPlexConnected(MediaContainer plexSections) {
            History = new Stack<MediaContainer>();
            History.Push(plexSections);
            BuildItemList(plexSections);
        }

        //static void NewItemFetcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        //    throw new NotImplementedException();
        //}

        //static void NewItemFetcher_ProgressChanged(object sender, ProgressChangedEventArgs e) {
        //    throw new NotImplementedException();
        //}

        //static void NewItemFetcher_DoWork(object sender, DoWorkEventArgs e) {
            
        //    throw new NotImplementedException();
        //}



        static void BuildItemList(MediaContainer responseContainer) {
            List<ListItem> tmpList = new List<ListItem>();

            if (responseContainer.Directory != null && responseContainer.Directory.Count > 0) {
                tmpList.AddRange(responseContainer.Directory.ToList().ConvertAll<ListItem>(dic => new ListItem(dic)));
            }
            if (responseContainer.Video != null && responseContainer.Video.Count > 0) {
                tmpList.AddRange(responseContainer.Video.ToList().ConvertAll<ListItem>(vid => new ListItem(vid)));
            }
           // OnItemsFetched(tmpList);
        }
        

        static void PlexInterface_OnPlexError(Exception e) {
            OnErrorOccured(e);
        }
      
        internal static void FetchItems() {
            BuildItemList(null);
        }

        internal static void FetchItems(ListItem listItem) {
            if (listItem != null) {
                if (listItem.Directory != null) {
                    History.Push(PlexInterface.RequestPlexItems(new Uri(History.Peek().UriSource, listItem.Index.Contains("?") ? listItem.Index : VirtualPathUtility.AppendTrailingSlash(listItem.Index))));
                    BuildItemList(History.Peek());
                } else if (listItem.Video != null) {
                  
                }
            }
           
        }

        internal static void GetPrevious() {
            if (History != null && History.Count > 1) {
                History.Pop();                
                BuildItemList(History.Peek());
            }
        }

        internal static void BuildMenuItems(List<IMenuItem> ChildMenuItems) {
            OnItemsFetched(ChildMenuItems);
        }
    }
}
