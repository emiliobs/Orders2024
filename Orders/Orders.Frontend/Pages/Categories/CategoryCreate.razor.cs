using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Categories
{
    public partial class CategoryCreate
    {
        // Declaring a private instance variable 'country' of type Country and initializing it with a new instance of Country
        private Category category = new Category();

        // Declaring a private instance variable 'countryForm' of type CountryForm
        private CategoryForm categoryForm;

        // Declaring a public property 'Repository' of type IRepository and injecting it
        [Inject]
        public IRepository Repository { get; set; } = null!;

        // Declaring a public property 'SweetAlertService' of type SweetAlertService and injecting it
        [Inject]
        public SweetAlertService SweetAlertService { get; set; } = null;

        // Declaring a public property 'NavigationManager' of type NavigationManager and injecting it
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;


        // Declaring a private asynchronous method 'CreateAsync'
        private async Task CreateAsync()
        {
            // Sending a POST request to the '/api/countries' endpoint with the 'country' object
            var responseHttp = await Repository.PostAsync("/api/categories", category);
            // Checking if there's an error in the response
            if (responseHttp.Error)
            {
                // Retrieving the error message
                var message = await responseHttp.GetErrorMessageAsync();
                // Displaying a SweetAlert modal with the error message
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                // Exiting the method
                return;
            }

            // Invoking the 'Return' method
            Return();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");
        }

        // Declaring a private method 'Return'
        private void Return()
        {
            // Setting the 'FormPostPostedSuccessFully' property of 'countryForm' to true
            categoryForm.FormPostPostedSuccessFully = true;
            // Navigating to the '/countries' page
            NavigationManager.NavigateTo("/categories");
        }
    }
}