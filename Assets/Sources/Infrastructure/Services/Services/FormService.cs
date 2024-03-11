﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.PresentationsInterfaces.Views.Forms;

namespace Sources.Infrastructure.Services.Services
{
    public class FormService : IFormService
    {
        private readonly Dictionary<string, IForm> _forms = new Dictionary<string, IForm>();

        public void Add(IForm formView, string name = null)
        {
            _forms.Add(name ?? formView.Name, formView);
            formView.Hide();
        }
        
        public void Show<T>() where T : IFormView => 
            Show(typeof(T).Name);

        public void Show(string name)
        {
            if (_forms.ContainsKey(name) == false)
                throw new NullReferenceException(nameof(name));

            IForm activeForm = _forms[name];
            
            _forms.Values
                .Except(new List<IForm>() {activeForm})
                .ToList()
                .ForEach(form => form.Hide());
            
            activeForm.Show();
        }

        public void Hide<T>() where T : IFormView
        {
            string name = typeof(T).Name;

            if (_forms.ContainsKey(name) == false)
                throw new NullReferenceException(nameof(name));

            IForm activeForm = _forms[name];

            if (activeForm == null)
                throw new NullReferenceException(nameof(activeForm));
            
            activeForm.Hide();
        }
    }
}