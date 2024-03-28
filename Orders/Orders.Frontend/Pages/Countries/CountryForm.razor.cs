using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Countries
{
    public partial class CountryForm
    {
        private EditContext editContext = null!;

        [EditorRequired, Parameter]
        public Country Country { get; set; } = null!;

        [EditorRequired, Parameter]
        public EventCallback OnValidSubmit { get; set; }

        [EditorRequired, Parameter]
        public EventCallback ReturnValue { get; set; }

        [Inject]
        public SweetAlertService SweetAlertService { get; set; } = null!;

        public bool FormPostPostedSuccessFully { get; set; }

    }
}
