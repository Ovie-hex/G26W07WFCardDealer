using System;
using System.Collections.Generic;
using System.Text;

namespace G26W07WFCardDealer
{
    internal class Card
    {
        public int suit = 0;
        public int value = 0;

        public static List<Card> rolledCard = new List<Card>();

        static public int getRank(List<Card> cards)
        {
            if (cards.Count != 5) return 0;

            List<int> suits = new List<int>();
            List<int> values = new List<int>();

            foreach (Card card in cards) {
                suits.Add(card.suit);
                values.Add(card.value);
            }
            // 로열 스트레이트 플러쉬
            if (suits.All(s => s == suits[0]) && values.OrderBy(v => v).SequenceEqual([0, 9, 10, 11, 12])) return 12;
            // 백 스트레이트 플러쉬
            else if (suits.All(s => s == suits[0]) && values.OrderBy(v => v).SequenceEqual([0, 1, 2, 3, 4])) return 11;
            // 스트레이트 플러쉬
            else if (suits.All(s => s == suits[0]) && values.OrderBy(v => v).SequenceEqual([values.Min(), values.Min() + 1, values.Min() + 2, values.Min() + 3, values.Min() + 4])) return 10;
            // 포카드
            else if ((values.Count(v => v == values.Min()) == 4 && values.Count(v => v == values.Max()) == 1) || (values.Count(v => v == values.Min()) == 1 && values.Count(v => v == values.Max()) == 4)) return 9;
            // 풀하우스
            else if ((values.Count(v => v == values.Min()) == 3 && values.Count(v => v == values.Max()) == 2) || (values.Count(v => v == values.Min()) == 2 && values.Count(v => v == values.Max()) == 3)) return 8;
            // 플러쉬
            else if (suits.All(s => s == suits[0])) return 7;
            // 마운틴
            else if (values.OrderBy(v => v).SequenceEqual([0, 9, 10, 11, 12]) && !suits.All(s => s == suits[0])) return 6;
            // 백스트레이트
            else if (values.OrderBy(v => v).SequenceEqual([0, 1, 2, 3, 4]) && !suits.All(s => s == suits[0])) return 5;
            // 스트레이트
            else if (values.OrderBy(v => v).SequenceEqual([values.Min(), values.Min() + 1, values.Min() + 2, values.Min() + 3, values.Min() + 4]) && !suits.All(s => s == suits[0])) return 4;
            // 트리플
            else if (values.GroupBy(v => v).Select(g => g.Count()).Any(v => v == 3)) return 3;
            // 투 페어
            else if (values.GroupBy(v => v).Select(g => g.Count()).Count(v => v == 2) == 2) return 2;
            // 원 페어
            else if (values.GroupBy(v => v).Select(g => g.Count()).Any(v => v == 2)) return 1;


            // 노페어
            return 0;
        }

        public Card()
        {
           // 이걸 넣을 필요가 있었을까...
        }

        public int[] roll()
        {
            Random r = new();

            while (true)
            {
                this.suit = r.Next(4);
                this.value = r.Next(13);
                bool IsHaveSame = false;

                if (rolledCard.Count > 0)
                { 
                    foreach (Card c in rolledCard)
                    {
                        if (this.suit == c.suit && this.value == c.value)
                        {
                            IsHaveSame = true;
                        }
                    }
                }

                if (IsHaveSame) continue;
                else break;
            }

            rolledCard.Add(this);

            return new int[] { this.suit, this.value };
        }
        
    }
}
