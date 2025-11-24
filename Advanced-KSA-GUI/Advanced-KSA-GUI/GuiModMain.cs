using Brutal.ImGuiApi;
using StarMap.API;
using Brutal.Numerics;

namespace Advanced_KSA_GUI
{
    [StarMapMod]
    public class GuiModMain
    {
        private static bool fensterSichtbar = false;
        private static string eingabeText = "Hallo KSA!";
        private static float sliderWert = 0.5f;
        private static bool checkbox = false;

        [StarMapAfterGui]
        unsafe public void OnAfterUI(double dt)
        {
            // Hauptfenster Position und Größe
            ImGuiViewport* viewport = ImGui.GetMainViewport();
            float2 windowSize = new float2(500, 400);
            float2 windowPos = new float2(100, 100);

            ImGui.SetNextWindowSize(windowSize);
            ImGui.SetNextWindowPos(windowPos, ImGuiCond.FirstUseEver);

            ImGuiWindowFlags flags = ImGuiWindowFlags.None;

            if (ImGui.Begin("KSA GUI Mod", ref fensterSichtbar, flags))
            {
                // Überschrift
                ImGui.Text("KSA Mod!");
                ImGui.Separator();
                ImGui.Spacing();

                // Tabs
                if (ImGui.BeginTabBar("ModTabs"))
                {
                    if (ImGui.BeginTabItem("Steuerung"))
                    {
                        ZeichneTab_Steuerung();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Einstellungen"))
                    {
                        ZeichneTab_Einstellungen();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Info"))
                    {
                        ZeichneTab_Info();
                        ImGui.EndTabItem();
                    }

                    ImGui.EndTabBar();
                }

                // Schließen Button
                ImGui.Spacing();
                ImGui.Separator();
                if (ImGui.Button("Fenster schließen", new float2(150, 30)))
                {
                    fensterSichtbar = false;
                }
            }
            ImGui.End();

            // Toggle-Button in der Ecke wenn Fenster geschlossen
            if (!fensterSichtbar)
            {
                ImGui.SetNextWindowPos(new float2(10, 10), ImGuiCond.Always);
                ImGui.SetNextWindowSize(new float2(200, 60));

                if (ImGui.Begin("ModToggle", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize))
                {
                    if (ImGui.Button("Mod test  öffnen", new float2(180, 40)))
                    {
                        fensterSichtbar = true;
                    }
                }
                ImGui.End();
            }
        }

        private static void ZeichneTab_Steuerung()
        {
            ImGui.Text("Steuerungs-Optionen");
            ImGui.Spacing();


            // Slider
            ImGui.Text($"Wert: {sliderWert:F2}");
            ImGui.SliderFloat("##slider", ref sliderWert, 0.0f, 1.0f);

            ImGui.Spacing();

            // Checkbox
            ImGui.Checkbox("Option aktivieren", ref checkbox);

            ImGui.Spacing();
            ImGui.Spacing();

        }

        private static void ZeichneTab_Einstellungen()
        {
            ImGui.Text("Einstellungen");
            ImGui.Spacing();
            ImGui.Spacing();

            ImGui.TextWrapped("Hier können verschiedene Einstellungen für die Mod konfiguriert werden.");

            ImGui.Spacing();
            ImGui.Spacing();

        }

        private static void ZeichneTab_Info()
        {
            ImGui.Text("Mod Information");
            ImGui.Separator();
            ImGui.Spacing();

            ImGui.Text("Name: Advanced KSA GUI Mod");
            ImGui.Text("Version: 0.0.1");

            ImGui.Spacing();
            ImGui.Spacing();

            ImGui.TextWrapped("Diese Mod demonstriert wie man ein GUI-Fenster in Kitten Space Agency erstellt mit ImGui und StarMap.");

            ImGui.Spacing();

            ImGui.TextColored(new float4(0.2f, 1.0f, 0.2f, 1.0f), "Status: Aktiv");
        }
    }
}