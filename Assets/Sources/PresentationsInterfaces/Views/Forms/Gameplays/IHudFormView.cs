using Sources.PresentationsInterfaces.Ui.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplays
{
    public interface IHudFormView
    {
        IButtonView PauseButton { get; }
        IButtonView InventoryButton { get; }
        IButtonView LootInventoryButton { get; }
    }
}