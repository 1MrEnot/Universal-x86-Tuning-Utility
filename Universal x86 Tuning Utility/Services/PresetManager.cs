﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Universal_x86_Tuning_Utility.Services
{
    public class Preset
    {
        public int apuTemp { get; set; }
        public int apuSkinTemp { get; set; }
        public int apuSTAPMPow { get; set; }
        public int apuSTAPMTime { get; set; }
        public int apuFastPow { get; set; }
        public int apuSlowPow { get; set; }
        public int apuSlowTime { get; set; }
        public int apuCpuTdc { get; set; }
        public int apuCpuEdc { get; set; }
        public int apuSocTdc { get; set; }
        public int apuSocEdc { get; set; }
        public int apuGfxTdc { get; set; }
        public int apuGfxEdc { get; set; }
        public int apuGfxClk { get; set; }
        public int pboScalar { get; set; }
        public int coAllCore { get; set; }

        public int dtCpuTemp { get; set; }
        public int dtCpuPPT { get; set; }
        public int dtCpuTDC { get; set; }
        public int dtCpuEDC { get; set; }

        public int boostProfile { get; set; }

        public int IntelPL1 { get; set; }
        public int IntelPL2 { get; set; }
        public int rsr { get; set; }
        public int boost { get; set; }
        public int imageSharp { get; set; }

        public int ccd1Core1 { get; set; }
        public int ccd1Core2 { get; set; }
        public int ccd1Core3 { get; set; }
        public int ccd1Core4 { get; set; }
        public int ccd1Core5 { get; set; }
        public int ccd1Core6 { get; set; }
        public int ccd1Core7 { get; set; }
        public int ccd1Core8 { get; set; }

        public string commandValue { get; set; }

        public bool isApuTemp { get; set; }
        public bool isApuSkinTemp { get; set; }
        public bool isApuSTAPMPow { get; set; }
        public bool isApuSTAPMTime { get; set; }
        public bool isApuFastPow { get; set; }
        public bool isApuSlowPow { get; set; }
        public bool isApuSlowTime { get; set; }
        public bool isApuCpuTdc { get; set; }
        public bool isApuCpuEdc { get; set; }
        public bool isApuSocTdc { get; set; }
        public bool isApuSocEdc { get; set; }
        public bool isApuGfxTdc { get; set; }
        public bool isApuGfxEdc { get; set; }
        public bool isApuGfxClk { get; set; }
        public bool isPboScalar { get; set; }
        public bool isCoAllCore { get; set; }

        public bool isDtCpuTemp { get; set; }
        public bool isDtCpuPPT { get; set; }
        public bool isDtCpuTDC { get; set; }
        public bool isDtCpuEDC { get; set; }

        public bool isIntelPL1 { get; set; }
        public bool isIntelPL2 { get; set; }

        public bool isRadeonGraphics { get; set; }
        public bool isAntiLag { get; set; }
        public bool isRSR { get; set; }
        public bool isBoost { get; set; }
        public bool isImageSharp { get; set; }
        public bool isSync { get; set; }

        public bool IsCCD1Core1 { get; set; }
        public bool IsCCD1Core2 { get; set; }
        public bool IsCCD1Core3 { get; set; }
        public bool IsCCD1Core4 { get; set; }
        public bool IsCCD1Core5 { get; set; }
        public bool IsCCD1Core6 { get; set; }
        public bool IsCCD1Core7 { get; set; }
        public bool IsCCD1Core8 { get; set; }
    }

    public class PresetManager
    {
        private string _filePath;
        private Dictionary<string, Preset> _presets;

        public PresetManager(string filePath)
        {
            _filePath = filePath;
            _presets = new Dictionary<string, Preset>();
            LoadPresets();
        }

        public IEnumerable<string> GetPresetNames()
        {
            return _presets.Keys;
        }

        public Preset GetPreset(string presetName)
        {
            if (_presets.ContainsKey(presetName))
            {
                return _presets[presetName];
            }
            else
            {
                return null;
            }
        }

        public void SavePreset(string name, Preset preset)
        {
            _presets[name] = preset;
            SavePresets();
        }

        public void DeletePreset(string name)
        {
            _presets.Remove(name);
            SavePresets();
        }

        private void LoadPresets()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _presets = JsonConvert.DeserializeObject<Dictionary<string, Preset>>(json);
            }
            else
            {
                _presets = new Dictionary<string, Preset>();
            }
        }


        private void SavePresets()
        {
            string json = JsonConvert.SerializeObject(_presets, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}