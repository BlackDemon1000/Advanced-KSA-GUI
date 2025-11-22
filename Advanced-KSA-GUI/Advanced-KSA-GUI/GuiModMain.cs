using Brutal.UI;
using Brutal.UI.Styles;
using StarMap.API;
using System;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace GuiMod
{
    [StarMapMod]
    public class GuiModMain
    {
        private static bool fensterSichtbar = false;
        private static Rect fensterPosition = new Rect(100, 100, 400, 300);

        // Beispiel-Daten für das GUI
        private static string eingabeText = "Hallo KSA!";
        private static float sliderWert = 0.5f;
        private static bool checkbox = false;
        private static int selectedTab = 0;

        [StarMapInitialize]
        public static void Initialize()
        {
            StarMap.API.Log.Info("GUI Mod wurde geladen!");
        }

        [StarMapUpdate]
        public static void Update()
        {
            // Toggle Fenster mit F8 Taste
            if (Input.GetKeyDown(KeyCode.F8))
            {
                fensterSichtbar = !fensterSichtbar;
                StarMap.API.Log.Info($"GUI Fenster: {(fensterSichtbar ? "geöffnet" : "geschlossen")}");
            }
        }

        [StarMapGUI]
        public static void OnGUI()
        {
            if (!fensterSichtbar)
                return;

            // GUI Skin verwenden für besseres Aussehen
            GUI.skin = HighLogic.Skin;

            // Fenster zeichnen
            fensterPosition = GUILayout.Window(
                12345,
                fensterPosition,
                ZeichneFensterInhalt,
                "Meine KSA Mod - GUI Fenster",
                GUILayout.MinWidth(400),
                GUILayout.MinHeight(300)
            );
        }

        private static void ZeichneFensterInhalt(int windowID)
        {
            GUILayout.BeginVertical();

            // Überschrift
            GUILayout.Label("KSA Mod Test Mod!", GUI.skin.label);
            GUILayout.Space(10);

            // Tabs
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Steuerung", selectedTab == 0 ? GUI.skin.button : GUI.skin.box))
                selectedTab = 0;
            if (GUILayout.Button("Einstellungen", selectedTab == 1 ? GUI.skin.button : GUI.skin.box))
                selectedTab = 1;
            if (GUILayout.Button("Info", selectedTab == 2 ? GUI.skin.button : GUI.skin.box))
                selectedTab = 2;
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            // Tab-Inhalte
            switch (selectedTab)
            {
                case 0:
                    ZeichneTab_Steuerung();
                    break;
                case 1:
                    ZeichneTab_Einstellungen();
                    break;
                case 2:
                    ZeichneTab_Info();
                    break;
            }

            GUILayout.FlexibleSpace();

            // Schließen-Button unten
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Schließen", GUILayout.Width(100)))
            {
                fensterSichtbar = false;
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            // Fenster verschiebbar machen
            GUI.DragWindow();
        }

        private static void ZeichneTab_Steuerung()
        {
            GUILayout.Label("Steuerungs-Tab", GUI.skin.box);
            GUILayout.Space(5);

            // Textfeld
            GUILayout.BeginHorizontal();
            GUILayout.Label("Texteingabe:", GUILayout.Width(120));
            eingabeText = GUILayout.TextField(eingabeText, GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            // Slider
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Wert: {sliderWert:F2}", GUILayout.Width(120));
            sliderWert = GUILayout.HorizontalSlider(sliderWert, 0f, 1f, GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            // Checkbox
            checkbox = GUILayout.Toggle(checkbox, "Option aktivieren");

            GUILayout.Space(10);

            // Action Button
            if (GUILayout.Button("Aktion ausführen"))
            {
                StarMap.API.Log.Info($"Aktion ausgeführt! Text: {eingabeText}, Wert: {sliderWert}");
            }
        }

        private static void ZeichneTab_Einstellungen()
        {
            GUILayout.Label("Einstellungen-Tab", GUI.skin.box);
            GUILayout.Space(10);

            GUILayout.Label("Hier können verschiedene Einstellungen");
            GUILayout.Label("für deine Mod konfiguriert werden.");

            GUILayout.Space(10);

            if (GUILayout.Button("Einstellungen speichern"))
            {
                StarMap.API.Log.Info("Einstellungen gespeichert!");
            }
        }

        private static void ZeichneTab_Info()
        {
            GUILayout.Label("Info-Tab", GUI.skin.box);
            GUILayout.Space(10);

            GUILayout.Label("KSA GUI Mod");
            GUILayout.Label("Version: 1.0.0");
            GUILayout.Space(5);
            GUILayout.Label("Drücke F8 um das Fenster zu öffnen/schließen");
            GUILayout.Space(10);
            GUILayout.Label("Diese Mod zeigt wie man ein GUI-Fenster");
            GUILayout.Label("in Kitten Space Agency erstellt.");
        }
    }
}
