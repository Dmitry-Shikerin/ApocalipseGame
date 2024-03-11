using Sources.ControllersInterfaces.Presenters;
using Sources.PresentationsInterfaces.Views.Forms;

namespace Sources.Presentations.Views.Forms
{
    public class FormBase<T> : PresentableView<T>, IFormView where T : IPresenter
    {
    }
}