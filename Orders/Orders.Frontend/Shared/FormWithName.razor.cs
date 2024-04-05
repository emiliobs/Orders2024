using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Orders.Shared.Interfaces;

namespace Orders.Frontend.Shared
{
    public partial class FormWithName<TModel> where TModel : IEntityWithName
    {
        // Declaring a private instance variable 'editContext' of type EditContext and initializing it to null
        private EditContext editContext = null!;

        // Declaring a public property 'Country' of type Country and marking it as a required parameter
        [EditorRequired, Parameter]
        public TModel Model { get; set; } = default!;

        [EditorRequired, Parameter]
        public String Label { get; set; } = null!;

        // Declaring a public property 'OnValidSubmit' of type EventCallback and marking it as a required parameter
        [EditorRequired, Parameter]
        public EventCallback OnValidSubmit { get; set; }

        // Declaring a public property 'ReturnAction' of type EventCallback and marking it as a required parameter
        [EditorRequired, Parameter]
        public EventCallback ReturnAction { get; set; }

        // Declaring a public property 'SweetAlertService' of type SweetAlertService and injecting it
        [Inject]
        public SweetAlertService SweetAlertService { get; set; } = null!;

        // Declaring a public property 'FormPostPostedSuccessFully' of type bool
        public bool FormPostPostedSuccessFully { get; set; }

        protected override void OnInitialized()
        {
            editContext = new(Model);
        }

        // Declaring a private asynchronous method 'OnBeforeInternalNavigation' with a parameter of type LocationChangingContext
        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            // Checking if the form was edited and if the form post was successful
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostPostedSuccessFully)
            {
                return;
            }

            // Displaying a confirmation dialog using SweetAlert
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "Deseas abandonar la página y perder los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });

            // Determining user's choice
            var confirm = !string.IsNullOrEmpty(result.Value);

            // If user confirms, allow navigation; otherwise, prevent it
            if (confirm)
            {
                return;
            }

            // Prevents navigation if the user chooses not to navigate away from the current page
            context.PreventNavigation();
        }
    }
}