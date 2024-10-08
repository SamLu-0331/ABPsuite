using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Misars.Foundation.App.Patients
{
    public class Patient : PatientBase
    {
        //<suite-custom-code-autogenerated>
        protected Patient()
        {

        }

        public Patient(Guid id, DateTime birthday, string? name = null, string? phone = null)
            : base(id, birthday, name, phone)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}