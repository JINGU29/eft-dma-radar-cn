using eft_dma_radar.Common.Misc;
using eft_dma_radar.Common.Misc.Data.EFT;
using eft_dma_radar.Tarkov.Features.MemoryWrites;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.UI.Pages;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eft_dma_radar.UI.ESP
{
    public sealed class ESPHotkeyWidget : ESPWidget
    {
        private static Config Config => Program.Config;
        private readonly float _padding;
        private bool _showKey = true;
        private bool _showKeyType = true;
        private bool _onlyActive = false;
        private float _lastCalculatedHeight = 300f;

        /// <summary>
        /// Constructs an ESP Hotkey Widget.
        /// </summary>
        public ESPHotkeyWidget(SKGLControl parent, SKPoint location, bool minimized, float scale)
            : base(parent, "快捷键", location, new SKSize(350, 300), scale, true)
        {
            Minimized = minimized;
            _padding = 6f * scale;
            SetScaleFactor(scale);
        }

        public override void SetScaleFactor(float scale)
        {
            base.SetScaleFactor(scale);

            _hotkeyFont.Size = 13 * scale;

            _lastCalculatedHeight = 0f;
        }

        /// <summary>
        /// Calculate the required height for the widget based on content
        /// </summary>
        private float CalculateRequiredHeight(List<HotkeyDisplayModel> hotkeysToDisplay)
        {
            var lineSpacing = _hotkeyFont.Spacing;
            var height = _padding * 2;
            height += lineSpacing * 1.5f;

            if (hotkeysToDisplay?.Any() == true)
                height += hotkeysToDisplay.Count * lineSpacing;
            else
                height += lineSpacing;

            height += lineSpacing * 0.5f;

            return height;
        }

        /// <summary>
        /// Update widget size if the required height has changed
        /// </summary>
        private void UpdateWidgetSize(float requiredHeight)
        {
            if (Math.Abs(requiredHeight - _lastCalculatedHeight) > 1f)
            {
                var newSize = new SKSize(Size.Width, requiredHeight);

                if (this.GetType().BaseType?.GetMethod("UpdateSize") != null)
                {
                    this.GetType().BaseType?.GetMethod("UpdateSize")?.Invoke(this, new object[] { newSize });
                }
                else
                {
                    var sizeProperty = this.GetType().BaseType?.GetProperty("Size");
                    if (sizeProperty?.CanWrite == true)
                        sizeProperty.SetValue(this, newSize);
                }

                _lastCalculatedHeight = requiredHeight;
            }
        }

        public override void Draw(SKCanvas canvas)
        {
            base.Draw(canvas);

            if (Minimized)
                return;

            var mainWindow = MainWindow.Window;
            var generalSettingsControl = mainWindow?.GeneralSettingsControl;

            var hotkeyList = generalSettingsControl?.hotkeyListView?.ItemsSource as System.Collections.ObjectModel.ObservableCollection<HotkeyDisplayModel>;
            var hotkeysToDisplay = new List<HotkeyDisplayModel>();

            if (hotkeyList?.Count > 0)
            {
                hotkeysToDisplay = hotkeyList.ToList();

                if (_onlyActive)
                    hotkeysToDisplay = hotkeysToDisplay.Where(h => IsHotkeyActive(h.Action, generalSettingsControl)).ToList();
            }

            var requiredHeight = CalculateRequiredHeight(hotkeysToDisplay);
            UpdateWidgetSize(requiredHeight);

            if (generalSettingsControl?.hotkeyListView?.ItemsSource == null || hotkeyList == null || hotkeyList.Count == 0)
            {
                canvas.Save();
                canvas.ClipRect(ClientRectangle);

                var emptyLineSpacing = _hotkeyFont.Spacing;
                var emptyDrawPt = new SKPoint(ClientRectangle.Left + _padding, ClientRectangle.Top + emptyLineSpacing * 0.8f + _padding);

                var emptyText = "No hotkeys configured";
                canvas.DrawText(emptyText, emptyDrawPt, SKTextAlign.Left, _hotkeyFont, _hotkeyTextPaint);

                canvas.Restore();
                return;
            }

            canvas.Save();
            canvas.ClipRect(ClientRectangle);

            var lineSpacing = _hotkeyFont.Spacing;
            var drawPt = new SKPoint(ClientRectangle.Left + _padding, ClientRectangle.Top + lineSpacing * 0.8f + _padding);

            var showKeySymbol = _showKey ? "[x]" : "[ ]";
            var showKeyTypeSymbol = _showKeyType ? "[x]" : "[ ]";
            var onlyActiveSymbol = _onlyActive ? "[x]" : "[ ]";

            var filtersText = $"过滤器: {showKeySymbol} 显示按键  {showKeyTypeSymbol} 显示类型  {onlyActiveSymbol} 仅活动";
            canvas.DrawText(filtersText, drawPt, SKTextAlign.Left, _hotkeyFont, _hotkeyTextPaint);

            drawPt.Y += lineSpacing * 1f;

            var nameColumnWidth = hotkeysToDisplay.Any() ? hotkeysToDisplay.Max(x => _hotkeyFont.MeasureText(x.Action)) : 100f;
            var keyColumnWidth = _showKey && hotkeysToDisplay.Any() ? hotkeysToDisplay.Max(x => _hotkeyFont.MeasureText($"[{x.Key}]")) : 0f;
            var typeColumnWidth = _showKeyType && hotkeysToDisplay.Any() ? hotkeysToDisplay.Max(x => _hotkeyFont.MeasureText($"({x.Type})")) : 0f;

            var columnPadding = 15f * ScaleFactor;

            foreach (var hotkey in hotkeysToDisplay)
            {
                var isActive = IsHotkeyActive(hotkey.Action, generalSettingsControl);
                var textPaint = isActive ? _hotkeyActivePaint : _hotkeyInactivePaint;

                var currentX = drawPt.X;

                canvas.DrawText(hotkey.Action, currentX, drawPt.Y, SKTextAlign.Left, _hotkeyFont, textPaint);
                currentX += nameColumnWidth + columnPadding;

                if (_showKey)
                {
                    canvas.DrawText($"[{hotkey.Key}]", currentX, drawPt.Y, SKTextAlign.Left, _hotkeyFont, _hotkeyKeyPaint);
                    currentX += keyColumnWidth + columnPadding;
                }

                if (_showKeyType)
                    canvas.DrawText($"({hotkey.Type})", currentX, drawPt.Y, SKTextAlign.Left, _hotkeyFont, _hotkeyTypePaint);

                drawPt.Y += lineSpacing;
            }

            canvas.Restore();
        }

        public override bool HandleClientAreaClick(SKPoint point)
        {
            var lineSpacing = _hotkeyFont.Spacing;
            var startY = ClientRectangle.Top + lineSpacing * 0.8f + _padding;
            var filterLineY = startY;

            if (point.Y >= filterLineY - lineSpacing / 2 && point.Y <= filterLineY + lineSpacing / 2)
            {
                var startX = ClientRectangle.Left + _padding;
                var currentX = startX;

                var filtersText = "过滤器: ";
                var filtersWidth = _hotkeyFont.MeasureText(filtersText);
                currentX += filtersWidth;

                var showKeyCheckbox = _showKey ? "[x] 显示按键  " : "[ ] 显示按键  ";
                var showKeyWidth = _hotkeyFont.MeasureText(showKeyCheckbox);
                if (point.X >= currentX && point.X <= currentX + showKeyWidth)
                {
                    _showKey = !_showKey;
                    _lastCalculatedHeight = 0f;
                    return true;
                }

                currentX += showKeyWidth;

                var showKeyTypeCheckbox = _showKeyType ? "[x] 显示类型  " : "[ ] 显示类型  ";
                var showKeyTypeWidth = _hotkeyFont.MeasureText(showKeyTypeCheckbox);
                if (point.X >= currentX && point.X <= currentX + showKeyTypeWidth)
                {
                    _showKeyType = !_showKeyType;
                    _lastCalculatedHeight = 0f;
                    return true;
                }

                currentX += showKeyTypeWidth;

                var onlyActiveCheckbox = _onlyActive ? "[x] 仅活动" : "[ ] 仅活动";
                var onlyActiveWidth = _hotkeyFont.MeasureText(onlyActiveCheckbox);
                if (point.X >= currentX && point.X <= currentX + onlyActiveWidth)
                {
                    _onlyActive = !_onlyActive;
                    _lastCalculatedHeight = 0f;
                    return true;
                }
            }

            return false;
        }

        private static bool IsHotkeyActive(string actionName, GeneralSettingsControl generalSettingsControl)
        {
            try
            {
                var configActive = CheckFeatureActiveState(actionName);

                if (configActive)
                    return true;

                var toggleStatesField = typeof(GeneralSettingsControl)
                    .GetField("_toggleStates", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (toggleStatesField?.GetValue(generalSettingsControl) is Dictionary<string, bool> toggleStates)
                {
                    var configName = GetHotkeyConfigName(actionName);
                    if (toggleStates.TryGetValue(configName, out bool toggleState))
                        return toggleState;
                }

                return false;
            }
            catch (Exception ex)
            {
                Log.WriteLine($"IsHotkeyActive 异常: {ex.Message}");
                return false;
            }
        }

        private static string GetHotkeyConfigName(string displayName)
        {
            var configName = displayName.Replace(" ", "");
            var mapping = new Dictionary<string, string>
            {
                // Loot
                { "ShowLoot", nameof(HotkeyConfig.ShowLoot) },
                { "ShowWishlistLoot", nameof(HotkeyConfig.ShowWishlistLoot) },
                { "ShowMeds", nameof(HotkeyConfig.ShowMeds) },
                { "ShowFood", nameof(HotkeyConfig.ShowFood) },
                { "ShowWeapons", nameof(HotkeyConfig.ShowWeapons) },
                { "ShowBackpacks", nameof(HotkeyConfig.ShowBackpacks) },
                { "ShowContainers", nameof(HotkeyConfig.ShowContainers) },
                { "ImportantCorpseLoot", nameof(HotkeyConfig.ImportantCorpseLoot) },
                { "ImportantPlayerLoot", nameof(HotkeyConfig.ImportantPlayerLoot) },

                // ESP
                { "ToggleFuserESP", nameof(HotkeyConfig.ToggleFuserESP) },
                { "MiniRadarZoomIn", nameof(HotkeyConfig.MiniRadarZoomIn) },
                { "MiniRadarZoomOut", nameof(HotkeyConfig.MiniRadarZoomOut) },

                // Memory Writes - Global
                { "ToggleRageMode", nameof(HotkeyConfig.ToggleRageMode) },

                // Memory Writes - Aimbot
                { "ToggleAimbot", nameof(HotkeyConfig.ToggleAimbot) },
                { "EngageAimbot", nameof(HotkeyConfig.EngageAimbot) },
                { "ToggleAimbotMode", nameof(HotkeyConfig.ToggleAimbotMode) },
                { "AimbotBone", nameof(HotkeyConfig.AimbotBone) },
                { "SafeLock", nameof(HotkeyConfig.SafeLock) },
                { "RandomBone", nameof(HotkeyConfig.RandomBone) },
                { "AutoBone", nameof(HotkeyConfig.AutoBone) },
                { "HeadshotAI", nameof(HotkeyConfig.HeadshotAI) },

                // Memory Writes - Weapons
                { "NoMalfunctions", nameof(HotkeyConfig.NoMalfunctions) },
                { "FastWeaponOps", nameof(HotkeyConfig.FastWeaponOps) },
                { "DisableWeaponCollision", nameof(HotkeyConfig.DisableWeaponCollision) },
                { "NoRecoil", nameof(HotkeyConfig.NoRecoil) },

                // Memory Writes - Movement
                { "InfiniteStamina", nameof(HotkeyConfig.InfiniteStamina) },
                { "WideLean", nameof(HotkeyConfig.WideLean) },
                { "WideLeanUp", nameof(HotkeyConfig.WideLeanUp) },
                { "WideLeanRight", nameof(HotkeyConfig.WideLeanRight) },
                { "WideLeanLeft", nameof(HotkeyConfig.WideLeanLeft) },
                { "MoveSpeed", nameof(HotkeyConfig.MoveSpeed) },

                // Memory Writes - World
                { "DisableShadows", nameof(HotkeyConfig.DisableShadows) },
                { "DisableGrass", nameof(HotkeyConfig.DisableGrass) },
                { "ClearWeather", nameof(HotkeyConfig.ClearWeather) },
                { "TimeOfDay", nameof(HotkeyConfig.TimeOfDay) },
                { "FullBright", nameof(HotkeyConfig.FullBright) },
                { "LootThroughWalls", nameof(HotkeyConfig.LootThroughWalls) },
                { "ExtendedReach", nameof(HotkeyConfig.ExtendedReach) },
                { "EngageLTW", nameof(HotkeyConfig.EngageLTW) },

                // Memory Writes - Camera
                { "NoVisor", nameof(HotkeyConfig.NoVisor) },
                { "NightVision", nameof(HotkeyConfig.NightVision) },
                { "ThermalVision", nameof(HotkeyConfig.ThermalVision) },
                { "ThirdPerson", nameof(HotkeyConfig.ThirdPerson) },
                { "OwlMode", nameof(HotkeyConfig.OwlMode) },
                { "InstantZoom", nameof(HotkeyConfig.InstantZoom) },

                // Memory Writes - Misc
                { "BigHeads", nameof(HotkeyConfig.BigHeads) },

                // General Settings
                { "AimviewWidget", nameof(HotkeyConfig.AimviewWidget) },
                { "DebugWidget", nameof(HotkeyConfig.DebugWidget) },
                { "PlayerInfoWidget", nameof(HotkeyConfig.PlayerInfoWidget) },
                { "ConnectGroups", nameof(HotkeyConfig.ConnectGroups) },
                { "MaskNames", nameof(HotkeyConfig.MaskNames) },
                { "ZoomOut", nameof(HotkeyConfig.ZoomOut) },
                { "ZoomIn", nameof(HotkeyConfig.ZoomIn) },
                { "BattleMode", nameof(HotkeyConfig.BattleMode) },
                { "QuestHelper", nameof(HotkeyConfig.QuestHelper) }
            };

            return mapping.TryGetValue(configName, out var mappedName) ? mappedName : configName;
        }

        private static bool CheckFeatureActiveState(string actionName)
        {
            try
            {
                switch (actionName)
                {
                    // Loot
                    case "显示战利品":
                        return Config.ProcessLoot;
                    case "显示心愿单":
                        return Config.LootWishlist;
                    case "显示药品":
                        return LootFilterControl.ShowMeds;
                    case "显示食物":
                        return LootFilterControl.ShowFood;
                    case "显示武器":
                        return LootFilterControl.ShowWeapons;
                    case "显示背包":
                        return LootFilterControl.ShowBackpacks;
                    case "显示容器":
                        return Config.Containers.Show;
                    case "重要尸体战利品":
                        return Config.EntityTypeSettings?.GetSettings("Corpse")?.ShowImportantLoot ?? false;
                    case "重要玩家战利品":
                        return Config.PlayerTypeSettings?.Settings?.Values?.Any(s => s.ShowImportantLoot) ?? false;

                    // Fuser ESP
                    case "切换融合器ESP":
                        return ESPForm.ShowESP;
                    case "小雷达放大":
                    case "小雷达缩小":
                        return false;
                    case "融合器任务信息":
                        return Config.ESP.ShowQuestInfoWidget;
                    case "融合器重要尸体战利品":
                        return Config.ESP.EntityTypeESPSettings?.GetSettings("Corpse")?.ShowImportantLoot ?? false;
                    case "融合器重要玩家战利品":
                        return Config.ESP.PlayerTypeESPSettings?.Settings?.Values?.Any(s => s.ShowImportantLoot) ?? false;

                    // Memory Writes - Global
                    case "切换狂暴模式":
                        return Config.MemWrites.RageMode;

                    // Memory Writes - Aimbot
                    case "切换自瞄":
                        return Config.MemWrites.Aimbot.Enabled;
                    case "启动自瞄":
                        return Aimbot.Engaged;
                    case "切换自瞄模式":
                        return false;
                    case "自瞄骨骼":
                        return false;
                    case "安全锁定":
                        return Config.MemWrites.Aimbot.SilentAim.SafeLock;
                    case "随机骨骼":
                        return Config.MemWrites.Aimbot.RandomBone.Enabled;
                    case "自动骨骼":
                        return Config.MemWrites.Aimbot.SilentAim.AutoBone;
                    case "AI爆头":
                        return Config.MemWrites.Aimbot.HeadshotAI;

                    // Memory Writes - Weapons
                    //case "无故障":
                    //    return Config.MemWrites.NoWeaponMalfunctions;
                    case "快速武器操作":
                        return Config.MemWrites.FastWeaponOps;
                    case "禁用武器碰撞":
                        return Config.MemWrites.DisableWeaponCollision;
                    case "无后座":
                        return Config.MemWrites.NoRecoil;

                    // Memory Writes - Movement
                    case "无限耐力":
                        return Config.MemWrites.InfStamina;
                    case "宽探头":
                        return Config.MemWrites.WideLean.Enabled;
                    case "宽探头向上":
                        return Config.MemWrites.WideLean.Enabled && WideLean.Direction == WideLean.EWideLeanDirection.Up;
                    case "宽探头向右":
                        return Config.MemWrites.WideLean.Enabled && WideLean.Direction == WideLean.EWideLeanDirection.Right;
                    case "宽探头向左":
                        return Config.MemWrites.WideLean.Enabled && WideLean.Direction == WideLean.EWideLeanDirection.Left;
                    //case "移动速度":
                    //    return Config.MemWrites.MoveSpeed.Enabled;

                    // Memory Writes - World
                    //case "禁用阴影":
                    //    return Config.MemWrites.DisableShadows;
                    case "禁用草地":
                        return Config.MemWrites.DisableGrass;
                    case "晴朗天气":
                        return Config.MemWrites.ClearWeather;
                    case "时间":
                        return Config.MemWrites.TimeOfDay.Enabled;
                    case "全亮度":
                        return Config.MemWrites.FullBright.Enabled;
                    //case "穿墙摸包":
                    //    return Config.MemWrites.LootThroughWalls.Enabled;
                    //case "延长距离":
                    //    return Config.MemWrites.ExtendedReach.Enabled;
                    //case "启动穿墙缩放":
                    //    return LootThroughWalls.ZoomEngaged;

                    // Memory Writes - Camera
                    case "无面罩":
                        return Config.MemWrites.NoVisor;
                    case "夜视":
                        return Config.MemWrites.NightVision;
                    case "热成像":
                        return Config.MemWrites.ThermalVision;
                    case "第三人称":
                        return Config.MemWrites.ThirdPerson;
                    case "猫头鹰模式":
                        return Config.MemWrites.OwlMode;
                    //case "瞬间缩放":
                    //    return Config.MemWrites.FOV.InstantZoomActive;

                    // Memory Writes - Misc
                    case "大头模式":
                        return Config.MemWrites.BigHead.Enabled;

                    // General Settings
                    case "自瞄视野组件":
                        return Config.AimviewWidgetEnabled;
                    case "调试组件":
                        return Config.ShowDebugWidget;
                    case "玩家信息组件":
                        return Config.ShowInfoTab;
                    case "战利品信息组件":
                        return Config.ShowLootInfoWidget;
                    case "任务信息组件":
                        return Config.ShowQuestInfoWidget;

                    case "连接队伍":
                        return Config.ConnectGroups;
                    case "隐藏名称":
                        return Config.MaskNames;
                    case "玩家置顶":
                        return Config.PlayersOnTop;
                    case "缩小":
                    case "放大":
                        return false;
                    case "战斗模式":
                        return Config.BattleMode;
                    case "任务助手":
                        return Config.QuestHelper.Enabled;

                    default:
                        Log.WriteLine($"CheckFeatureActiveState 中未知的操作名称: '{actionName}'");
                        return false;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLine($"CheckFeatureActiveState 检查 '{actionName}' 时发生异常: {ex.Message}");
                return false;
            }
        }

        #region Static Paint Objects
        private static readonly SKPaint _hotkeyTextPaint = new()
        {
            Color = SKColors.White,
            IsStroke = false,
            IsAntialias = true,
        };

        private static readonly SKPaint _hotkeyActivePaint = new()
        {
            Color = SKColors.LightGreen,
            IsStroke = false,
            IsAntialias = true,
        };

        private static readonly SKPaint _hotkeyInactivePaint = new()
        {
            Color = SKColors.Gray,
            IsStroke = false,
            IsAntialias = true,
        };

        private static readonly SKPaint _hotkeyKeyPaint = new()
        {
            Color = SKColors.Yellow,
            IsStroke = false,
            IsAntialias = true,
        };

        private static readonly SKPaint _hotkeyTypePaint = new()
        {
            Color = SKColors.Cyan,
            IsStroke = false,
            IsAntialias = true,
        };

        private static readonly SKFont _hotkeyFont = new(SKTypeface.FromFamilyName("Microsoft YaHei") ?? SKTypeface.Default, 13) { Subpixel = true };
        #endregion
    }
}