using Sources.PresentationsInterfaces.Views.Forms;

namespace Sources.InfrastructureInterfaces.Services.FormServices
{
    public interface IFormService
    {
        void Show<T>() where T : IFormView;
        void Show(string formName);
        void Hide<T>() where T : IFormView;
    }
}