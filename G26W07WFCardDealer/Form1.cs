using System.Xml.Linq;

namespace G26W07WFCardDealer
{

    public partial class Form1 : Form
    {

        private static List<Card> cards = [new Card(), new Card(), new Card(), new Card(), new Card()];

        private static string[] suits = ["spades", "hearts", "diamonds", "clubs"];
        private static string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];

        private static string[] rankText = [
            "노 페어 😭",
            "원 페어",
            "투 페어",
            "트리플",
            "스트레이트",
            "백스트레이트",
            "마운틴",
            "플러쉬",
            "풀하우스",
            "포카드",
            "스트레이트 플러쉬",
            "백 스트레이트 플러쉬",
            "👑로열 스트레이트 플러쉬👑🤣🤣🤣"
            ];


        public Form1()
        {
            InitializeComponent();

        }

        private void OnDeal(object sender, EventArgs e)
        {
            Control.ControlCollection cardcontrols = CardFrame.Controls;

            for (int i = 0; i < 5; i++)
            {
                Card.rolledCard.Clear();

                int[] val = cards[i].roll();

                int suit = val[0];
                int value = val[1];

                PictureBox? card = cardcontrols[i] as PictureBox;

                string name = $"{values[value]}_of_{suits[suit]}";

                if (value == 10 || value == 11 || value == 12)
                {
                    name += "2";
                }

                card.Image = Properties.Resources.ResourceManager.GetObject(name) as Image;

                Result.Text = rankText[Card.getRank(cards)];
            }
        }

    }
}
