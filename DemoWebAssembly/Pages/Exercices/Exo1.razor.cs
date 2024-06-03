namespace DemoWebAssembly.Pages.Exercices
{
    public partial class Exo1
    {
        public string Username { get; set; }

        public List<string> Reponses { get; set; }

        public bool GameIsOver { get; set; }

        protected override void OnInitialized()
        {
            Reponses = new List<string>();
        }

        public void RegisterResponse(string response)
        {
            Reponses.Add(response);
            if(Reponses.Count > 2)
            {
                GameIsOver = true;
            }
        }
    }
}
