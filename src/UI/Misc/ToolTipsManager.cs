using HandyControl.Controls;
using System.Windows.Controls;
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using DataGrid = System.Windows.Controls.DataGrid;
using ListBox = System.Windows.Controls.ListBox;
using ListView = System.Windows.Controls.ListView;
using NumericUpDown = HandyControl.Controls.NumericUpDown;
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;

namespace eft_dma_radar.UI.Misc
{
    public static class TooltipManager
    {

        public static void AssignLootTooltips(UserControl context)
        {
            if (context.FindName("chkShowLoot") is CheckBox chkShowLoot)
                chkShowLoot.ToolTip = "切换战利品显示的开启或关闭。";

            if (context.FindName("chkShowLootWishlist") is CheckBox chkShowLootWishlist)
                chkShowLootWishlist.ToolTip = "追踪您账户的战利品心愿单（仅限手动添加，不适用于自动添加的物品）。";

            if (context.FindName("sldrPriceRange") is HandyControl.Controls.TextBox txtRegularValue)
                txtRegularValue.ToolTip = "设置物品显示的最小和贵重卢布价值";

            if (context.FindName("chkPricePerSlot") is CheckBox chkPricePerSlot)
                chkPricePerSlot.ToolTip = "使用每格价格而非物品总价值。";

            if (context.FindName("rdbFleaPrices") is RadioButton rdbFleaPrices)
                rdbFleaPrices.ToolTip = "战利品价格使用基于~实时市场价值的跳蚤市场最优价格。";

            if (context.FindName("rdbTraderPrices") is RadioButton rdbTraderPrices)
                rdbTraderPrices.ToolTip = "战利品价格使用显示物品的最高商人价格。";

            if (context.FindName("chkHideCorpses") is CheckBox chkHideCorpses)
                chkHideCorpses.ToolTip = "隐藏死亡玩家和AI的尸体。";

            if (context.FindName("chkShowMeds") is CheckBox chkShowMeds)
                chkShowMeds.ToolTip = "只显示医疗物品。";

            if (context.FindName("chkShowFood") is CheckBox chkShowFood)
                chkShowFood.ToolTip = "只显示食物和饮料物品。";

            if (context.FindName("chkShowBackpacks") is CheckBox chkShowBackpacks)
                chkShowBackpacks.ToolTip = "只显示背包战利品。";

            if (context.FindName("txtLootToSearch") is HandyControl.Controls.TextBox txtLootToSearch)
                txtLootToSearch.ToolTip = "逗号分隔的物品名称搜索（例如 'GPU,keycard'）。";

            if (context.FindName("chkStaticContainers") is CheckBox chkStaticContainers)
                chkStaticContainers.ToolTip = "在地图上显示静态容器。由于最近的塔科夫反作弊措施，您无法看到容器内容。";

            if (context.FindName("sldrContainerDistance") is Slider sldrContainerDistance)
                sldrContainerDistance.ToolTip = "战利品容器渲染的最大距离。";

            if (context.FindName("chkContainersSelectAll") is CheckBox chkContainersSelectAll)
                chkContainersSelectAll.ToolTip = "切换所有容器的开启或关闭。";

            if (context.FindName("chkContainersHideSearched") is CheckBox chkContainersHideSearched)
                chkContainersHideSearched.ToolTip = "隐藏已被网络实体（通常只有你自己）搜索过的容器。";
        }

        public static void AssignLootFilterTooltips(UserControl context)
        {
            if (context.FindName("cboLootFilters") is HandyControl.Controls.ComboBox cboLootFilters)
                cboLootFilters.ToolTip = "要修改的战利品过滤器。";

            if (context.FindName("txtNewGroupName") is HandyControl.Controls.TextBox txtNewGroupName)
                txtNewGroupName.ToolTip = "新战利品过滤器的名称。";

            if (context.FindName("btnRemoveGroup") is Button btnRemoveGroup)
                btnRemoveGroup.ToolTip = "移除选中的战利品过滤器。";

            if (context.FindName("btnAddGroup") is Button btnAddGroup)
                btnAddGroup.ToolTip = "添加新的战利品过滤器。";

            if (context.FindName("chkEnabled") is CheckBox chkEnabled)
                chkEnabled.ToolTip = "切换战利品过滤器的开启/关闭。";

            if (context.FindName("chkStatic") is CheckBox chkStatic)
                chkStatic.ToolTip = "取消勾选后，在重启/关闭雷达时移除战利品过滤器。";

            if (context.FindName("chkNotify") is CheckBox chkNotify)
                chkNotify.ToolTip = "当战利品过滤器中的选中物品存在时通知您。";

            if (context.FindName("nudNotifyTime") is HandyControl.Controls.NumericUpDown nudNotifyTime)
                nudNotifyTime.ToolTip = "战利品物品通知的重复延迟（0 为禁用）。";

            if (context.FindName("nudGroupIndex") is HandyControl.Controls.NumericUpDown nudGroupIndex)
                nudGroupIndex.ToolTip = "物品显示的优先级（数字越小越先显示）";

            if (context.FindName("txtGroupName") is HandyControl.Controls.TextBox txtGroupName)
                txtGroupName.ToolTip = "选中战利品过滤器的名称。";

            if (context.FindName("txtItemSearch") is HandyControl.Controls.TextBox txtItemSearch)
                txtItemSearch.ToolTip = "输入以搜索和过滤可用物品。";

            if (context.FindName("btnAddItem") is Button btnAddItem)
                btnAddItem.ToolTip = "将选中物品添加到您的战利品过滤器。";

            if (context.FindName("cboItems") is HandyControl.Controls.ComboBox cboItems)
                cboItems.ToolTip = "可添加的战利品物品。";

            if (context.FindName("itemsListView") is ListView itemsListView)
                itemsListView.ToolTip = "您当前过滤的战利品条目。启用/禁用或编辑颜色和通知状态。";

            if (context.FindName("btnRemoveItem") is Button btnRemoveItem)
                btnRemoveItem.ToolTip = "从您的战利品过滤器中移除选中物品。";
        }

        public static void AssignESPTips(UserControl context)
        {
            if (context.FindName("chkEnableChams") is CheckBox chkEnableChams)
                chkEnableChams.ToolTip = "启用穿模功能。这将对所有玩家（除了你自己和队友）启用穿模。";

            if (context.FindName("chkImportantItemChams") is CheckBox chkImportantItemChams)
                chkImportantItemChams.ToolTip = "对重要战利品物品应用穿模。";

            if (context.FindName("chkQuestItemChams") is CheckBox chkQuestItemChams)
                chkQuestItemChams.ToolTip = "对任务相关物品应用穿模。";

            if (context.FindName("chkContainerChams") is CheckBox chkContainerChams)
                chkContainerChams.ToolTip = "对静态容器应用穿模。";

            if (context.FindName("cboChamsEntityType") is System.Windows.Controls.ComboBox cboChamsEntityType)
                cboChamsEntityType.ToolTip = "选择要自定义穿模的实体。";

            if (context.FindName("rdbBasic") is RadioButton rdbBasic)
                rdbBasic.ToolTip = "这些基础穿模仅在目标可见时显示。无法更改颜色（始终为白色）。";

            if (context.FindName("rdbVisible") is RadioButton rdbVisible)
                rdbVisible.ToolTip = "这些高级穿模仅在目标可见时显示。您可以更改颜色。";

            if (context.FindName("rdbVisCheckGlow") is RadioButton rdbVisCheckGlow)
                rdbVisCheckGlow.ToolTip = "基于可见性检查渲染发光穿模。";

            if (context.FindName("rdbVisCheckFlat") is RadioButton rdbVisCheckFlat)
                rdbVisCheckFlat.ToolTip = "渲染带有可见性检查的扁平穿模。";

            if (context.FindName("rdbWireFrame") is RadioButton rdbWireFrame)
                rdbWireFrame.ToolTip = "渲染线框样式穿模。";

            if (context.FindName("btnchamsVisibleColor") is Button btnchamsVisibleColor)
                btnchamsVisibleColor.ToolTip = "设置可见目标的穿模颜色。";

            if (context.FindName("btnchamsInvisibleColor") is Button btnchamsInvisibleColor)
                btnchamsInvisibleColor.ToolTip = "设置不可见目标的穿模颜色。";

            if (context.FindName("chkEnableFuser") is CheckBox chkEnableFuser)
                chkEnableFuser.ToolTip = "启动ESP窗口。这将在黑色背景上渲染ESP。将此窗口移动到要融合的屏幕。";

            if (context.FindName("chkAutoFullscreen") is CheckBox chkAutoFullscreen)
                chkAutoFullscreen.ToolTip = "为ESP窗口设置'自动全屏'。\n设置后，应用程序启动时会自动在选定屏幕上进入全屏模式。";

            if (context.FindName("cboHighAlert") is HandyControl.Controls.ComboBox cboHighAlert)
                cboHighAlert.ToolTip = "启用'高级警报'ESP功能。当您被瞄准超过0.5秒时激活。\n" +
                    "您视野内的目标（在您前方）将绘制指向您角色的瞄准线。\n视野外的目标将使屏幕边框变红。\n" +
                    "无 = 功能禁用\n所有玩家 = 对玩家和机器人(AI)启用\n仅人类 = 仅对人类控制的玩家启用。";

            if (context.FindName("nudFPSCap") is NumericUpDown nudFPSCap)
                nudFPSCap.ToolTip = "设置ESP窗口的帧率上限。通常这可以是您游戏电脑显示器的刷新率。这也有助于减少雷达电脑的资源使用。";

            if (context.FindName("sldrFuserFontScale") is Slider sldrFuserFontScale)
                sldrFuserFontScale.ToolTip = "设置ESP窗口的字体缩放系数。\n如果您以非常高的分辨率渲染，您可能需要增加此值。";

            if (context.FindName("sldrFuserLineScale") is Slider sldrFuserLineScale)
                sldrFuserLineScale.ToolTip = "设置ESP窗口的线条缩放系数。\n如果您以非常高的分辨率渲染，您可能需要增加此值。";

            if (context.FindName("chkCrosshairEnabled") is CheckBox chkCrosshairEnabled)
                chkCrosshairEnabled.ToolTip = "切换在ESP上渲染准星。";

            if (context.FindName("cboCrosshairType") is HandyControl.Controls.ComboBox cboCrosshairType)
                cboCrosshairType.ToolTip = "要显示的准星类型。";

            if (context.FindName("sldrFuserCrosshairScale") is Slider sldrFuserCrosshairScale)
                sldrFuserCrosshairScale.ToolTip = "调整准星缩放。";

            if (context.FindName("cboPlayerRenderMode") is HandyControl.Controls.ComboBox cboPlayerRenderMode)
                cboPlayerRenderMode.ToolTip = "选择玩家的显示方式（例如，骨骼、方框或头部圆点）。";

            if (context.FindName("chkFuserPlayerLabels") is CheckBox chkFuserPlayerLabels)
                chkFuserPlayerLabels.ToolTip = "显示实体标签/名称。";

            if (context.FindName("chkFuserPlayerWeapons") is CheckBox chkFuserPlayerWeapons)
                chkFuserPlayerWeapons.ToolTip = "显示实体持有的武器/弹药。";

            if (context.FindName("chkFuserPlayerDistance") is CheckBox chkFuserPlayerDistance)
                chkFuserPlayerDistance.ToolTip = "显示实体与本地玩家的距离。";

            if (context.FindName("cboAIRenderMode") is HandyControl.Controls.ComboBox cboAIRenderMode)
                cboAIRenderMode.ToolTip = "选择AI的显示方式（例如，骨骼、方框或头部圆点）。";

            if (context.FindName("chkFuserAILabels") is CheckBox chkFuserAILabels)
                chkFuserAILabels.ToolTip = "显示实体标签/名称。";

            if (context.FindName("chkFuserAIWeapons") is CheckBox chkFuserAIWeapons)
                chkFuserAIWeapons.ToolTip = "显示实体持有的武器/弹药。";

            if (context.FindName("chkFuserAIDistance") is CheckBox chkFuserAIDistance)
                chkFuserAIDistance.ToolTip = "显示实体与本地玩家的距离。";

            if (context.FindName("chkFuserLoot") is CheckBox chkFuserLoot)
                chkFuserLoot.ToolTip = "启用在ESP窗口中渲染战利品物品。";

            if (context.FindName("chkFuserExfils") is CheckBox chkFuserExfils)
                chkFuserExfils.ToolTip = "启用在ESP窗口中渲染撤离点。";

            if (context.FindName("chkFuserExplosives") is CheckBox chkFuserExplosives)
                chkFuserExplosives.ToolTip = "启用在ESP窗口中渲染手榴弹。";

            if (context.FindName("chkFuserMagazine") is CheckBox chkFuserMagazine)
                chkFuserMagazine.ToolTip = "显示您当前装填的弹匣弹药数量/类型。";

            if (context.FindName("chkFuserDistances") is CheckBox chkFuserDistances)
                chkFuserDistances.ToolTip = "启用在ESP实体下方渲染'距离'。这是您与实体之间的游戏内距离。";

            if (context.FindName("chkFuserMines") is CheckBox chkFuserMines)
                chkFuserMines.ToolTip = "显示地雷。";

            if (context.FindName("chkFuserFireportAim") is CheckBox chkFuserFireportAim)
                chkFuserFireportAim.ToolTip = "在屏幕上显示基础枪口轨迹，让您看到子弹将飞向何处。瞄准时消失。";

            if (context.FindName("chkFuserAimbotFOV") is CheckBox chkFuserAimbotFOV)
                chkFuserAimbotFOV.ToolTip = "启用在ESP窗口中心渲染'自瞄视野圈'。这用于自瞄目标锁定。";

            if (context.FindName("chkFuserRaidStats") is CheckBox chkFuserRaidStats)
                chkFuserRaidStats.ToolTip = "在ESP窗口右上角显示战局统计（玩家数量等）。";

            if (context.FindName("chkFuserAimbotLock") is CheckBox chkFuserAimbotLock)
                chkFuserAimbotLock.ToolTip = "启用在您的枪口和当前锁定的自瞄目标之间渲染一条线。";

            if (context.FindName("chkFuserStatusText") is CheckBox chkFuserStatusText)
                chkFuserStatusText.ToolTip = "在屏幕顶部中心显示状态文本（自瞄状态、宽探头等）";

            if (context.FindName("chkFuserFPS") is CheckBox chkFuserFPS)
                chkFuserFPS.ToolTip = "启用在ESP窗口左上角显示ESP渲染帧率(FPS)。";

            if (context.FindName("sldrFuserLootDistance") is Slider sldrFuserLootDistance)
                sldrFuserLootDistance.ToolTip = "设置本地玩家渲染普通战利品的最大距离。";

            if (context.FindName("sldrFuserImportantLootDistance") is Slider sldrFuserImportantLootDistance)
                sldrFuserImportantLootDistance.ToolTip = "设置本地玩家渲染重要战利品的最大距离。";

            if (context.FindName("sldrFuserContainerDistance") is Slider sldrFuserContainerDistance)
                sldrFuserContainerDistance.ToolTip = "设置本地玩家渲染容器的最大距离。";

            if (context.FindName("sldrFuserQuestDistance") is Slider sldrFuserQuestDistance)
                sldrFuserQuestDistance.ToolTip = "设置本地玩家渲染静态任务物品/位置的最大距离。必须开启任务助手。";

            if (context.FindName("sldrFuserExplosivesDistance") is Slider sldrFuserExplosivesDistance)
                sldrFuserExplosivesDistance.ToolTip = "设置本地玩家渲染爆炸物的最大距离。";
        }

        public static void AssignMemoryWritingTooltips(UserControl context)
        {
            if (context.FindName("chkMasterSwitch") is CheckBox chkMasterSwitch)
                chkMasterSwitch.ToolTip = "启用/禁用内存写入功能。禁用时，将阻止应用程序中发生任何内存写入。\n\n" +
                "关于'风险'\n" +
                "- 大部分风险源于这些功能大幅增强了您的能力，使其他玩家更容易举报您。\n" +
                "- 玩家举报是被封禁的首要风险。\n" +
                "- 这些功能目前均未被'检测'，但未来有非常小的风险可能被检测到。";

            if (context.FindName("btnAntiAFK") is Button btnAntiAFK)
                btnAntiAFK.ToolTip = "启用反挂机功能。防止游戏因不活动而关闭。\n" +
                "注意：在塔科夫主菜单时，*准备挂机前*设置此功能。\n" +
                "注意：如果离开主菜单，可能需要重新设置。\n" +
                "注意：如果设置困难，您的内存可能已被分页。尝试关闭/重新打开游戏。";

            if (context.FindName("btnGymHack") is Button btnGymHack)
                btnGymHack.ToolTip = "启用健身房作弊功能，使您的锻炼始终成功。\n" +
                "注意：启用此功能后，您必须在15秒内开始锻炼才能应用作弊。正常完成第一次重复，然后它应该对后续重复生效。\n" +
                "注意：您仍然必须'左键点击'每个重复。";

            if (context.FindName("chkRageMode") is CheckBox chkRageMode)
                chkRageMode.ToolTip = "启用狂暴模式功能。启用时，将后座/晃动设置为0%，自瞄骨骼对所有目标覆盖为'头部'。\n此设置在程序退出时不保存。\n" +
                "警告：这被标记为风险功能，因为它将您的后座设置为0%且您将始终爆头，其他玩家可能会注意到。";

            if (context.FindName("chkEnableAimbot") is CheckBox chkEnableAimbot)
                chkEnableAimbot.ToolTip = "启用自瞄（静默瞄准）功能。我们采用自瞄预测（仅在线战局）来补偿子弹下坠/弹道和目标移动。\n" +
                "警告：这被标记为风险功能，因为其他玩家更容易举报您。请谨慎使用。";

            if (context.FindName("rdbFOV") is RadioButton rdbFOV)
                rdbFOV.ToolTip = "启用自瞄的视野(FOV)目标模式。这将优先选择视野内最靠近屏幕中心的目标。";

            if (context.FindName("rdbCQB") is RadioButton rdbCQB)
                rdbCQB.ToolTip = "启用自瞄的近身战斗(CQB)目标模式。\n这将优先选择*视野内*距离您玩家最近的目标。";

            if (context.FindName("cboTargetBone") is HandyControl.Controls.ComboBox cboTargetBone)
                cboTargetBone.ToolTip = "设置自瞄的目标骨骼。";

            if (context.FindName("sldrAimbotFOV") is Slider sldrAimbotFOV)
                sldrAimbotFOV.ToolTip = "设置自瞄目标的视野。根据您的偏好增加/降低此值。请注意当您瞄准/开镜时，视野范围会变窄。";

            if (context.FindName("chkAimbotSafeLock") is CheckBox chkAimbotSafeLock)
                chkAimbotSafeLock.ToolTip = "如果您的目标离开视野半径，则解锁自瞄。\n" +
                "注意：解锁后可能'重新锁定'另一个目标（或同一目标）。";

            if (context.FindName("chkAimbotDisableReLock") is CheckBox chkAimbotDisableReLock)
                chkAimbotDisableReLock.ToolTip = "当当前目标死亡/不再有效时，禁用自瞄'重新锁定'新目标。\n防止在您反应过来之前意外快速击杀多个目标。";

            if (context.FindName("chkAimbotAutoBone") is CheckBox chkAimbotAutoBone)
                chkAimbotAutoBone.ToolTip = "根据您瞄准的位置自动选择最佳骨骼目标。";

            if (context.FindName("chkHeadshotAI") is CheckBox chkHeadshotAI)
                chkHeadshotAI.ToolTip = "无论其他设置如何，始终对AI目标爆头。";

            if (context.FindName("chkAimbotRandomBone") is CheckBox chkAimbotRandomBone)
                chkAimbotRandomBone.ToolTip = "每次射击后选择随机自瞄骨骼。您可以设置身体区域的自定义百分比值。\n注意：这将覆盖静默瞄准的'自动骨骼'。";

            if (context.FindName("sldrAimbotRNGHead") is Slider sldrAimbotRNGHead)
                sldrAimbotRNGHead.ToolTip = "瞄准头部的几率。";

            if (context.FindName("sldrAimbotRNGTorso") is Slider sldrAimbotRNGTorso)
                sldrAimbotRNGTorso.ToolTip = "瞄准躯干的几率。";

            if (context.FindName("sldrAimbotRNGArms") is Slider sldrAimbotRNGArms)
                sldrAimbotRNGArms.ToolTip = "瞄准手臂的几率。";

            if (context.FindName("sldrAimbotRNGLegs") is Slider sldrAimbotRNGLegs)
                sldrAimbotRNGLegs.ToolTip = "瞄准腿部的几率。";

            // 武器
            if (context.FindName("chkNoWeaponMalfunctions") is CheckBox chkNoWeaponMalfunctions)
                chkNoWeaponMalfunctions.ToolTip = "启用无武器故障功能。防止您的枪因哑火/过热等故障无法射击。\n" +
                "启用后，此功能将保持启用状态，直到您重新启动游戏。\n" +
                "直播安全！";

            if (context.FindName("chkFastMags") is CheckBox chkFastMags)
                chkFastMags.ToolTip = "允许您超快速装填/卸载弹匣。";

            if (context.FindName("chkFastWeaponOps") is CheckBox chkFastWeaponOps)
                chkFastWeaponOps.ToolTip = "使您的玩家武器操作（即时瞄准、装填弹匣等）更快。\n" +
                "注意：在装填弹匣时尝试治疗或执行其他操作可能会导致'双手忙碌'错误。";

            if (context.FindName("chkNoRecoil") is CheckBox chkNoRecoil)
                chkNoRecoil.ToolTip = "启用无后座/晃动写入功能。将鼠标悬停在后座/晃动滑块上以获取更多信息。\n" +
                "警告：这被标记为风险功能，因为它减少了您的后座/晃动，其他玩家可能会注意到您异常的扫射模式。";

            if (context.FindName("sldrNoRecoilAmt") is Slider sldrNoRecoilAmt)
                sldrNoRecoilAmt.ToolTip = "设置应用正常后座的百分比（例如：0 = 0%或无后座）。这会影响射击时枪的上下运动。";

            if (context.FindName("sldrNoSwayAmt") is Slider sldrNoSwayAmt)
                sldrNoSwayAmt.ToolTip = "设置应用瞄准镜晃动的百分比（例如：0 = 0%或无晃动）。这会影响查看瞄准镜/瞄准器时的晃动运动。";

            // 移动
            if (context.FindName("chkInfiniteStamina") is CheckBox chkInfiniteStamina)
                chkInfiniteStamina.ToolTip = "启用无限耐力功能。防止您耗尽耐力/呼吸，并绕过疲劳减益。由于安全原因，您只能在战局结束后禁用此功能。\n" +
                "注意：您的脚步声将是静音的，这是正常的。\n" +
                "注意：开启此功能时您不会获得耐力/力量经验。\n" +
                "注意：在较高负重时，您可能会遇到服务器不同步。您可以尝试禁用1.2倍移动速度，或减轻负重。MULE兴奋剂在这里也有帮助。\n" +
                "警告：这被标记为风险功能，因为其他玩家可以看到您'滑行'而不是跑步，这在视觉上是明显的。";

            if (context.FindName("chkMoveSpeed") is CheckBox chkMoveSpeed)
                chkMoveSpeed.ToolTip = "启用/禁用1.2倍移动速度功能。这使您的玩家移动速度提高1.2倍。\n" +
                "注意：与无限耐力一起使用时，在较高携带重量下可能会导致服务器不同步。关闭此功能以减少不同步。\n" +
                "警告：这被标记为风险功能，因为其他玩家可以看到您移动速度比正常快。";

            if (context.FindName("chkWideLean") is CheckBox chkWideLean)
                chkWideLean.ToolTip = "全局启用/禁用宽探头。您仍需在快捷键管理器中设置快捷键。\n警告：这总体上是一个风险较高的写入功能。";

            if (context.FindName("sldrLeanAmt") is Slider sldrLeanAmt)
                sldrLeanAmt.ToolTip = "设置使用宽探头功能时应用的探头量。如果射击失败，您可能需要降低此值。";

            // 世界
            if (context.FindName("chkAlwaysDay") is CheckBox chkAlwaysDay)
                chkAlwaysDay.ToolTip = "启用始终白天/晴朗功能。这将战局内时间设置为始终中午12点（白天），并将天气设置为晴朗。";

            if (context.FindName("chkFullBright") is CheckBox chkFullBright)
                chkFullBright.ToolTip = "启用全亮度功能。这将使游戏世界更亮。";

            if (context.FindName("chkLTW") is CheckBox chkLTW)
                chkLTW.ToolTip = "启用穿墙摸包功能。这允许您穿墙摸取物品。\n" +
                "* 您可以正常摸取大多数任务物品/容器物品，最远3.8米。\n" +
                "* 您可以摸取松散战利品最远约1米（可能并不总是有效）。\n" +
                "* 要摸取松散战利品，某些物品您需要用枪械'瞄准'（使用'切换穿墙缩放'快捷键），它将使摄像机穿过墙壁。找到您的物品并摸取它。\n" +
                "警告：由于此功能的复杂性以及服务器端检查的存在，它被标记为有风险。";

            if (context.FindName("sldrLTWZoom") is Slider sldrLTWZoom)
                sldrLTWZoom.ToolTip = "设置穿墙摸包的缩放量。这是摄像机将穿过墙壁的距离。";

            // 相机
            if (context.FindName("chkNoVisor") is CheckBox chkNoVisor)
                chkNoVisor.ToolTip = "启用无面罩功能。这将移除某些面罩（如Altyn/Killa头盔）的视野障碍，给您清晰的视野。";

            if (context.FindName("chkNightVision") is CheckBox chkNightVision)
                chkNightVision.ToolTip = "启用夜视功能。这允许您在夜间无需夜视装备即可看到。";

            if (context.FindName("chkThermalVision") is CheckBox chkThermalVision)
                chkThermalVision.ToolTip = "启用热成像功能。这允许您以清晰的T-7视野看到。";

            if (context.FindName("chkThirdPerson") is CheckBox chkThirdPerson)
                chkThirdPerson.ToolTip = "切换到第三人称视角。";

            if (context.FindName("chkOwlMode") is CheckBox chkOwlMode)
                chkOwlMode.ToolTip = "360°相机，无限制的俯仰和偏航。";

            if (context.FindName("chkDisableScreenEffects") is CheckBox chkDisableScreenEffects)
                chkDisableScreenEffects.ToolTip = "禁用模糊、血迹、闪光和屏幕震动效果。";

            if (context.FindName("chkFOVChanger") is CheckBox chkFOVChanger)
                chkFOVChanger.ToolTip = "允许修改您的视野。";

            if (context.FindName("sldrFOVBase") is Slider sldrFOVBase)
                sldrFOVBase.ToolTip = "设置第一人称视角的视野";

            if (context.FindName("sldrADSFOV") is Slider sldrADSFOV)
                sldrADSFOV.ToolTip = "设置瞄准下 sights (ADS)的视野";

            if (context.FindName("sldrTPPFOV") is Slider sldrTPPFOV)
                sldrTPPFOV.ToolTip = "设置第三人称视角的视野";

            // 杂项
            if (context.FindName("chkStreamerMode") is CheckBox chkStreamerMode)
                chkStreamerMode.ToolTip = "隐藏可能敏感的内容。";

            if (context.FindName("chkHideRaidCode") is CheckBox chkHideRaidCode)
                chkHideRaidCode.ToolTip = "从显示和日志中隐藏战局代码。";

            if (context.FindName("chkInstantPlant") is CheckBox chkInstantPlant)
                chkInstantPlant.ToolTip = "立即种植目标，无延迟。";
        }

        public static void AssignGeneralSettingsTooltips(UserControl context)
        {
            if (context.FindName("chkMapSetup") is CheckBox chkMapSetup)
                chkMapSetup.ToolTip = "切换'地图设置助手'以协助获取地图边界/缩放";

            if (context.FindName("chkESPWidget") is CheckBox chkESPWidget)
                chkESPWidget.ToolTip = "切换ESP'小部件'，在雷达窗口中提供迷你ESP。可以移动。";

            if (context.FindName("chkPlayerInfoWidget") is CheckBox chkPlayerInfoWidget)
                chkPlayerInfoWidget.ToolTip = "切换玩家信息'小部件'，为您提供战局中玩家/Boss的信息。可以移动。";

            if (context.FindName("chkConnectGroups") is CheckBox chkConnectGroups)
                chkConnectGroups.ToolTip = "通过半透明绿线连接组队的玩家。不适用于您自己的队伍。";

            if (context.FindName("chkHideNames") is CheckBox chkHideNames)
                chkHideNames.ToolTip = "隐藏ESP覆盖中的所有玩家名称。";

            if (context.FindName("chkMines") is CheckBox chkMines)
                chkMines.ToolTip = "在地图和ESP上显示地雷。";

            if (context.FindName("chkTeammateAimlines") is CheckBox chkTeammateAimlines)
                chkTeammateAimlines.ToolTip = "启用时，使队友瞄准线与主玩家长度相同";

            if (context.FindName("chkAIAimlines") is CheckBox chkAIAimlines)
                chkAIAimlines.ToolTip = "启用AI玩家的动态瞄准线。当您被瞄准时，瞄准线将延长。";

            if (context.FindName("chkDebugWidget") is CheckBox chkDebugWidget)
                chkDebugWidget.ToolTip = "切换调试'小部件'（仅绘制雷达帧率）。可以移动。";

            if (context.FindName("chkLootInfoWidget") is CheckBox chkLootInfoWidget)
                chkLootInfoWidget.ToolTip = "切换战利品'小部件'，显示战局中的顶级物品及其数量。可以移动。";

            if (context.FindName("nudFPSLimit") is NumericUpDown nudFPSLimit)
                nudFPSLimit.ToolTip = "设置雷达的帧率限制。这也有助于减少雷达电脑的资源使用。";

            if (context.FindName("sldrUIScale") is Slider sldrUIScale)
                sldrUIScale.ToolTip = "设置雷达/用户界面的缩放系数。对于高分辨率显示器，您可能需要增加此值。";

            if (context.FindName("sldrMaxDistance") is Slider sldrMaxDistance)
                sldrMaxDistance.ToolTip = "设置雷达及其许多功能的'最大距离'。这将影响敌方瞄准线、自瞄视野、ESP和自瞄。\n大多数情况下，您不需要将其设置为超过500。";

            if (context.FindName("sldrAimlineLength") is Slider sldrAimlineLength)
                sldrAimlineLength.ToolTip = "设置本地玩家/队友的瞄准线长度";

            if (context.FindName("sldrContainerDistance") is Slider sldrContainerDistance)
                sldrContainerDistance.ToolTip = "容器在ESP上显示的距离。";

            if (context.FindName("cboMonitor") is HandyControl.Controls.ComboBox cboMonitor)
                cboMonitor.ToolTip = "选择渲染ESP的显示器。";

            if (context.FindName("btnRefreshMonitors") is Button btnRefreshMonitors)
                btnRefreshMonitors.ToolTip = "自动检测塔科夫运行的游戏电脑显示器分辨率，并设置宽度/高度字段。游戏必须正在运行。";

            if (context.FindName("txtGameWidth") is HandyControl.Controls.TextBox txtFuserWidth)
                txtFuserWidth.ToolTip = "塔科夫运行的游戏电脑显示器的分辨率宽度。必须正确设置才能使自瞄视野/自瞄/ESP正常工作。";

            if (context.FindName("txtGameHeight") is HandyControl.Controls.TextBox txtFuserHeight)
                txtFuserHeight.ToolTip = "塔科夫运行的游戏电脑显示器的分辨率高度。必须正确设置才能使自瞄视野/自瞄/ESP正常工作。";

            if (context.FindName("chkQuestHelper") is CheckBox chkQuestHelper)
                chkQuestHelper.ToolTip = "切换任务助手功能。这将显示您当前活跃任务需要拾取/访问的物品和区域。";

            if (context.FindName("listQuests") is ListBox listQuests)
                listQuests.ToolTip = "活跃任务列表（进入战局后填充）。取消勾选任务以取消追踪。";

            if (context.FindName("btnWebRadarStart") is Button btnWebRadarStart)
                btnWebRadarStart.ToolTip = "启动网络雷达服务器。";

            if (context.FindName("chkWebRadarUPnP") is CheckBox chkWebRadarUPnP)
                chkWebRadarUPnP.ToolTip = "尝试使用UPnP自动打开端口。";

            if (context.FindName("lblWebRadarLink") is TextBlock lblWebRadarLink)
                lblWebRadarLink.ToolTip = "点击在浏览器中打开您的网络雷达URL。";

            if (context.FindName("txtWebRadarBindIP") is HandyControl.Controls.TextBox txtWebRadarBindIP)
                txtWebRadarBindIP.ToolTip = "服务器将绑定的IP地址。";

            if (context.FindName("txtWebRadarPort") is HandyControl.Controls.TextBox txtWebRadarPort)
                txtWebRadarPort.ToolTip = "网络雷达服务器的端口号。";

            if (context.FindName("txtWebRadarTickRate") is HandyControl.Controls.TextBox txtWebRadarTickRate)
                txtWebRadarTickRate.ToolTip = "网络雷达发送更新的频率（以Hz为单位）。";

            if (context.FindName("txtWebRadarPassword") is HandyControl.Controls.TextBox txtWebRadarPassword)
                txtWebRadarPassword.ToolTip = "连接网络雷达所需的密码。";

            if (context.FindName("cboTheme") is HandyControl.Controls.ComboBox cboTheme)
                cboTheme.ToolTip = "在深色和浅色主题之间选择。";

            if (context.FindName("hotkeyListView") is ListView hotkeyListView)
                hotkeyListView.ToolTip = "显示所有已分配的快捷键。";

            if (context.FindName("btnAddHotkey") is Button btnAddHotkey)
                btnAddHotkey.ToolTip = "添加新的快捷键绑定。";

            if (context.FindName("btnRemoveHotkey") is Button btnRemoveHotkey)
                btnRemoveHotkey.ToolTip = "移除选中的快捷键。";

            if (context.FindName("cboAction") is HandyControl.Controls.ComboBox cboAction)
                cboAction.ToolTip = "选择要分配快捷键的操作。";

            if (context.FindName("cboKey") is HandyControl.Controls.ComboBox cboKey)
                cboKey.ToolTip = "选择将触发选中操作的按键。";

            if (context.FindName("rdbOnKey") is RadioButton rdbOnKey)
                rdbOnKey.ToolTip = "按住按键时触发操作。";

            if (context.FindName("rdbToggle") is RadioButton rdbToggle)
                rdbToggle.ToolTip = "使用按键切换操作的开启和关闭。";
        }

        public static void AssignPlayerHistoryTooltips(UserControl context)
        {
            if (context.FindName("playerHistoryDataGrid") is DataGrid playerHistoryDataGrid)
                playerHistoryDataGrid.ToolTip = "Double click to add a recent player into the watchlist.";
        }

        public static void AssignWatchlistTooltips(UserControl context)
        {
            if (context.FindName("txtAccountID") is HandyControl.Controls.TextBox txtAccountID)
                txtAccountID.ToolTip = "The Account ID of the player.";

            if (context.FindName("txtReason") is HandyControl.Controls.TextBox txtReason)
                txtReason.ToolTip = "The reason why they are being watched.";

            if (context.FindName("btnClearForm") is Button btnClearForm)
                btnClearForm.ToolTip = "Clears the selected entry/form.";

            if (context.FindName("btnAddEntry") is Button btnAddEntry)
                btnAddEntry.ToolTip = "Add a new entry or update an existing one.";

            if (context.FindName("btnRemoveEntry") is Button btnRemoveEntry)
                btnRemoveEntry.ToolTip = "Remove the selected watchlist entry.";

            if (context.FindName("watchlistListView") is ListView watchlistListView)
                watchlistListView.ToolTip = "Click to select & edit an existing watchlist entry.";
        }
    }
}
