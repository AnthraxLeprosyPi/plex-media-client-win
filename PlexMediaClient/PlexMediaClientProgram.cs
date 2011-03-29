using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PlexMediaClient.Gui;

namespace PlexMediaClient {
    static class PlexMediaClientProgram {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPlexClientMain());
        }
    }
}
