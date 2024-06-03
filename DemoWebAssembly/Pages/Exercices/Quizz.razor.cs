using Microsoft.AspNetCore.Components;

namespace DemoWebAssembly.Pages.Exercices
{
    public partial class Quizz
    {
        [Parameter]
        public string Username { get; set; }
        [Parameter]
        public EventCallback<string> ReponseEvent { get; set; }
        public List<string> Questions { get; set; }
        public int Counter { get; set; }

        protected override void OnInitialized()
        {
            Questions = new List<string>();
            Questions.Add("Avez vous bien mangé à midi ?");
            Questions.Add("Appréciez vous BLazor ?");
            Questions.Add("Envie d'une sieste ?");

            Counter = 0;
        }

        public void Repondre(string r)
        {
            ReponseEvent.InvokeAsync(r);
            Counter++;
        }
    }
}
