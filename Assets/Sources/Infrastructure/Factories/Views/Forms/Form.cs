using System;
using Sources.ControllersInterfaces.Presenters;
using Sources.Presentations.Views.Forms;
using Sources.PresentationsInterfaces.Views.Forms;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.Forms
{
    public class Form<TFormView, TFormPresenter> : IForm
        where TFormView : FormBase<TFormPresenter>
        where TFormPresenter : IPresenter
    {
        private readonly TFormView _formView;

        public Form(Func<TFormView, TFormPresenter> presenterFactory, TFormView formView)
        {
            _formView = formView ? formView : throw new ArgumentNullException(nameof(formView));

            TFormPresenter formPresenter = presenterFactory.Invoke(_formView);
            
            _formView.Construct(formPresenter);

            Name = _formView.GetType().Name;
        }

        public string Name { get; }

        public void Hide() => 
            _formView.Hide();

        public void Show() => 
            _formView.Show();

        public void SetParent(Transform parentTransform) => 
            _formView.SetParent(parentTransform);

        public void SetTransformPosition(Transform position) => 
            _formView.SetTransformPosition(position);

        public void Destroy() => 
            _formView.Destroy();
    }
}