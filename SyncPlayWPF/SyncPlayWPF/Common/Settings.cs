using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SyncPlayWPF.Common {
    public class Settings {


        private static XElement basics = new XElement("Basics",
                            new XElement("Address", ""),
                            new XElement("Username", ""),
                            new XElement("Password", ""),
                            new XElement("RoomName", ""),
                            new XElement("PathToMediaPlayer", ""),
                            new XElement("PathToVideo", ""),
                            new XElement("AdditionalArguments", "")
                        );

        private static XElement behaviour = new XElement("Behaviour",
                            new XElement("SetMeAsReadyToSwtichByDefault", "False"),
                            new XElement("PauseWhenAUserLeavesOrGetDisconnected", "True"),
                            new XElement("SyncMyReadyToWatchStatusWithPlayState", "True"),
                            new XElement("NeverSlowDownOrRewindOther", "False"),
                            new XElement("FastForwardIfLaggingBehind", "True")
                        );

        private static XElement chatbehaviour = new XElement("Chat",
                            new XElement("ShowMessagesInPlayerWindow", "True"),
                            new XElement("PlayNotificationSound", "False"),
                            new XElement("DisableAnimations", "False"),
                            new XElement("AutoplayGifs", "False"),
                            new XElement("PreviewLinks", "False"),
                            new XElement("EnableOSDMessages", ""),
                            new XElement("ShowEventsInYourRoom", "True"),
                            new XElement("ShowEventsFromNonOperatorsInManagedRooms", "False"),
                            new XElement("ShowEventsInOtherRooms", "False"),
                            new XElement("ShowSlowingDownRevertingNotifications", "True"),
                            new XElement("ShowWarnings", "True")
                        );

        private static XElement securitySection = new XElement("Security",
                            new XElement("EnableTLS", "True"),
                            new XElement("HashFileNamesBeforeSending", "False"),
                            new XElement("HashPasswords", "True")
                        );

        private static XDocument NewConfig = new XDocument(
            new XElement("Config",
                new XComment("Basics and Stuff"),
                basics,
                new XComment("Syncplay Behaviour Settings"),
                behaviour,
                new XComment("Chat Behaviour Settings"),
                chatbehaviour,
                new XComment("Security Settings. Sekuriti"),
                securitySection
            )
        );

        public static void DefineSharedSettings() {
            Common.Shared.CurrentConfig = XDocument.Parse(System.IO.File.ReadAllText("SyncPlayConfig.xml"));
        }

        public static void RestoreDefaultConfiguration() {
            if (System.IO.File.Exists("SyncPlayConfig.xml")) {
                XDocument doc = XDocument.Parse(System.IO.File.ReadAllText("SyncPlayConfig.xml"));
                foreach (var sectiontag in NewConfig.Element("Config").Elements()) {
                    foreach (var proptag in sectiontag.Elements()) {
                        doc.Element("Config").Element(sectiontag.Name).Element(proptag.Name).Value = proptag.Value;
                    }
                }
                System.IO.File.WriteAllText("SyncPlayConfig.xml", doc.ToString());
            } else {
                var stringOut = NewConfig.ToString();
                System.IO.File.WriteAllText("SyncPlayConfig.xml", stringOut);
            }
        }

        public static void UpdateAttribute(XDocument doc, string section, string attribute, string value) {
            var sectionTag = doc.Element("Config").Element(section);
            if (sectionTag == null) {
                foreach (var sec in NewConfig.Element("Config").Elements()) {
                    if (sec.Name == section) {
                        doc.Element("Config").Add(sec);
                        sectionTag = doc.Element("Config").Element(section);
                        break;
                    }
                }
            }
            if (value == null) value = "";
            sectionTag.Element(attribute).Value = value;
        }

        private static string ConvertBoolean(bool? c) {
            return (bool)c ? "True" : "False";
        }

        private static string GetStringValue(XDocument doc, string section, string attribute) {
            return doc.Element("Config").Element(section).Element(attribute).Value;
        }

        private static bool GetBooleanValue(XDocument doc, string section, string attribute) {
            return doc.Element("Config").Element(section).Element(attribute).Value == "True" ? true : false;
        }

        public static bool GetCurrentConfigBoolValue(string section, string attribute) {
            return GetBooleanValue(Common.Shared.CurrentConfig, section, attribute);
        }

        public static string GetCurrentConfigStringValue(string section, string attribute) {
            return GetStringValue(Common.Shared.CurrentConfig, section, attribute);
        }

        public static void WriteConfigurationToView(Pages.SettingsPage Page) {
            XDocument doc = XDocument.Parse(System.IO.File.ReadAllText("SyncPlayConfig.xml"));

            Page.ServerAddressField.Text = GetStringValue(doc, "Basics", "Address");
            Page.UsernameField.Text = GetStringValue(doc, "Basics", "Username");
            Page.RoomNameField.Text = GetStringValue(doc, "Basics", "RoomName");
            Page.PathToMediaPlayer.Text = GetStringValue(doc, "Basics", "PathToMediaPlayer");
            Page.PathToVideo.Text = GetStringValue(doc, "Basics", "PathToVideo");
            Page.AdditionalArguments.Text = GetStringValue(doc, "Basics", "AdditionalArguments");

            Page.SetAsReadyToPlayByDefault.IsChecked = GetBooleanValue(doc, "Behaviour", "SetMeAsReadyToSwtichByDefault");
            Page.PauseWhenUserLeaves.IsChecked = GetBooleanValue(doc, "Behaviour", "PauseWhenAUserLeavesOrGetDisconnected");
            Page.SyncReadyToPlayWithPauseState.IsChecked = GetBooleanValue(doc, "Behaviour", "SyncMyReadyToWatchStatusWithPlayState");
            Page.NeverSlowDownOrRewindOthers.IsChecked = GetBooleanValue(doc, "Behaviour", "NeverSlowDownOrRewindOther");
            Page.FastForwardIfLagginingBehind.IsChecked = GetBooleanValue(doc, "Behaviour", "FastForwardIfLaggingBehind");

            Page.ShowMessagesInPlayerWindow.IsChecked = GetBooleanValue(doc, "Chat", "ShowMessagesInPlayerWindow");
            Page.PlayNotificationSound.IsChecked = GetBooleanValue(doc, "Chat", "PlayNotificationSound");
            Page.DisableAnimations.IsChecked = GetBooleanValue(doc, "Chat", "DisableAnimations");
            Page.AutoPlayGIFs.IsChecked = GetBooleanValue(doc, "Chat", "AutoplayGifs");
            Page.PreviewLinks.IsChecked = GetBooleanValue(doc, "Chat", "PreviewLinks");
            Page.EnableOSDMessages.IsChecked = GetBooleanValue(doc, "Chat", "EnableOSDMessages");
            Page.OSD_ShowEventsInYourRooms.IsChecked = GetBooleanValue(doc, "Chat", "ShowEventsFromNonOperatorsInManagedRooms");
            Page.OSD_ShowEventsInOtherRooms.IsChecked = GetBooleanValue(doc, "Chat", "ShowEventsInOtherRooms");
            Page.OSD_ShowSlowingNotifications.IsChecked = GetBooleanValue(doc, "Chat", "ShowSlowingDownRevertingNotifications");
            Page.OSD_ShowWarnings.IsChecked = GetBooleanValue(doc, "Chat", "ShowWarnings");

            Page.EnableTLS.IsChecked = GetBooleanValue(doc, "Security", "EnableTLS");
            Page.HashFileNamesBeforeSending.IsChecked = GetBooleanValue(doc, "Security", "HashFileNamesBeforeSending");
            Page.HashPasswords.IsChecked = GetBooleanValue(doc, "Security", "HashPasswords");
        }

        public static void ReadConfigurationFromView(Pages.SettingsPage Page) {
            XDocument doc = XDocument.Parse(System.IO.File.ReadAllText("SyncPlayConfig.xml"));

            UpdateAttribute(doc, "Basics", "Address", Page.ServerAddressField.Text);
            UpdateAttribute(doc, "Basics", "Username", Page.UsernameField.Text);
            UpdateAttribute(doc, "Basics", "Password", Page.PasswordField.ActualPassword);
            UpdateAttribute(doc, "Basics", "RoomName", Page.RoomNameField.Text);
            UpdateAttribute(doc, "Basics", "PathToMediaPlayer", Page.PathToMediaPlayer.Text);
            UpdateAttribute(doc, "Basics", "PathToVideo", Page.PathToVideo.Text);
            UpdateAttribute(doc, "Basics", "AdditionalArguments", Page.AdditionalArguments.Text);

            UpdateAttribute(doc, "Behaviour", "SetMeAsReadyToSwtichByDefault", ConvertBoolean(Page.SetAsReadyToPlayByDefault.IsChecked));
            UpdateAttribute(doc, "Behaviour", "PauseWhenAUserLeavesOrGetDisconnected", ConvertBoolean(Page.PauseWhenUserLeaves.IsChecked));
            UpdateAttribute(doc, "Behaviour", "SyncMyReadyToWatchStatusWithPlayState", ConvertBoolean(Page.SyncReadyToPlayWithPauseState.IsChecked));
            UpdateAttribute(doc, "Behaviour", "NeverSlowDownOrRewindOther", ConvertBoolean(Page.NeverSlowDownOrRewindOthers.IsChecked));
            UpdateAttribute(doc, "Behaviour", "FastForwardIfLaggingBehind", ConvertBoolean(Page.FastForwardIfLagginingBehind.IsChecked));

            UpdateAttribute(doc, "Chat", "ShowMessagesInPlayerWindow", ConvertBoolean(Page.ShowMessagesInPlayerWindow.IsChecked));
            UpdateAttribute(doc, "Chat", "PlayNotificationSound", ConvertBoolean(Page.PlayNotificationSound.IsChecked));
            UpdateAttribute(doc, "Chat", "DisableAnimations", ConvertBoolean(Page.DisableAnimations.IsChecked));
            UpdateAttribute(doc, "Chat", "AutoplayGifs", ConvertBoolean(Page.AutoPlayGIFs.IsChecked));
            UpdateAttribute(doc, "Chat", "PreviewLinks", ConvertBoolean(Page.PreviewLinks.IsChecked));
            UpdateAttribute(doc, "Chat", "EnableOSDMessages", ConvertBoolean(Page.EnableOSDMessages.IsChecked));
            UpdateAttribute(doc, "Chat", "ShowEventsInYourRoom", ConvertBoolean(Page.OSD_ShowEventsInYourRooms.IsChecked));
            UpdateAttribute(doc, "Chat", "ShowEventsFromNonOperatorsInManagedRooms", ConvertBoolean(Page.OSD_ShowEventsFromManagedRooms.IsChecked));
            UpdateAttribute(doc, "Chat", "ShowEventsInOtherRooms", ConvertBoolean(Page.OSD_ShowEventsInOtherRooms.IsChecked));
            UpdateAttribute(doc, "Chat", "ShowSlowingDownRevertingNotifications", ConvertBoolean(Page.OSD_ShowSlowingNotifications.IsChecked));
            UpdateAttribute(doc, "Chat", "ShowWarnings", ConvertBoolean(Page.OSD_ShowWarnings.IsChecked));

            UpdateAttribute(doc, "Security", "EnableTLS", ConvertBoolean(Page.EnableTLS.IsChecked));
            UpdateAttribute(doc, "Security", "HashFileNamesBeforeSending", ConvertBoolean(Page.HashFileNamesBeforeSending.IsChecked));
            UpdateAttribute(doc, "Security", "HashPasswords", ConvertBoolean(Page.HashPasswords.IsChecked));

            System.IO.File.WriteAllText("SyncPlayConfig.xml", doc.ToString());
        }

        public static void WriteConfigurationToFile(XDocument doc) {
            System.IO.File.WriteAllText("SyncPlayConfig.xml", doc.ToString());
        }
        public static void WriteConfigurationToFile() {
            System.IO.File.WriteAllText("SyncPlayConfig.xml", Common.Shared.CurrentConfig.ToString());
        }


    }
}
