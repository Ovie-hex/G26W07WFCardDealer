namespace G26W07WFCardDealer
{
    public partial class Form1 : Form
    {
        public static List<String> cards = [];
        

        public String setCard()
        {
            string[] suits = ["spades", "hearts", "diamonds", "clubs"];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];

            while (true)
            {
                Random random = new Random();
                int card = random.Next(suits.Length * values.Length);

                string suit = suits[card / values.Length];
                string value = values[card % values.Length];
                string name = $"{value}_of_{suit}";

                if (value == "jack" || value == "queen" || value == "king")
                {
                    name += "2";
                }

                if (!cards.Contains(name))
                {
                    cards.Add(name);
                    return name;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                cards.Clear();
            }
            Card1.Image = Properties.Resources.ResourceManager.GetObject(setCard()) as Image;
            Card2.Image = Properties.Resources.ResourceManager.GetObject(setCard()) as Image;
            Card3.Image = Properties.Resources.ResourceManager.GetObject(setCard()) as Image;
            Card4.Image = Properties.Resources.ResourceManager.GetObject(setCard()) as Image;
            Card5.Image = Properties.Resources.ResourceManager.GetObject(setCard()) as Image;
        }
    }
}
