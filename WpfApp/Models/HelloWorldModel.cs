using JetBrains.Annotations;

namespace Models
{
    public class HelloWorldModel
    {
        public HelloWorldModel()
        {
            Text = string.Empty;
        }

        [NotNull]
        public string Text { get; set; }
    }
}
