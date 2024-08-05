using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Frontend.Shared;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.States
{
    public partial class StatesCreate
    {
        private State state = new State();
        private FormWithName<State> stateForm;

        [Parameter]
        public int CountryId { get; set; }

        [Inject]
        public IRepository Repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public SweetAlertService SweetAlertService { get; set; } = null!;

        private async Task CreateAsync()
        {
            state.CountryId = CountryId;
            var responseHttp = await Repository.PostAsync($"/api/states", state);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            Return();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowCancelButton = true,
                Timer = 3000
            });

            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro Creado con Exíto.");
        }

        private void Return()
        {
            stateForm!.FormPostPostedSuccessFully = true;
            NavigationManager.NavigateTo($"/countries/details/{CountryId}");
        }
    }
}
