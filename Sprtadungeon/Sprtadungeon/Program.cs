using System.Xml.Linq;
using static Sprtadungeon.Program;
using static System.Console;


namespace Sprtadungeon
{

    internal class Program

    {
        public class Player
        {
            public string playerName { get; set; }
            public string playerJob { get; set; }
            public int playerLevel { get; set; }
            public int baseAtk { get; set; }
            public int addAtk { get; set; }
            public int baseDef { get; set; }
            public int addDef { get; set; }
            public int playerHp { get; set; }
            public int playerGold { get; set; }

            public Player(string name, string job, int level, int atk, int def, int hp, int gold)
            {
                playerName = name;
                playerJob = job;
                playerLevel = level;
                baseAtk = atk;
                baseDef = def;
                playerHp = hp;
                playerGold = gold;
            }
        }

        public static Player player;

        public interface ICharacter
        {
            string Name { get; }
            int Health { get; set; }
            int Attack { get; }
            bool IsDead { get; }
            void TakeDamage(int damage);
        }

        public class Item
        {
            public string name; // 아이템 이름
            public int price; // 아이템 가격
            public int effect; // 아이템 효과

            public  Item(string name, int price, int effect)
            {
                this.name = name;
                this.price = price;
                this.effect = effect;
            }

            public static int Count { get; private set; }

            class Shop
            {
                private List<Item> items; // 상점의 아이템 목록

                public Shop()
                {
                    items = new List<Item>();

                    // 아이템 목록을 초기화
                    items.Add(new Item("HP 회복약", 100, 10));
                    items.Add(new Item("MP 회복약", 100, 10));
                    items.Add(new Item("공격력 증가약", 500, 5));
                    items.Add(new Item("방어력 증가약", 500, 5));
                }


                public static Item item;

                static void CharacterSetting()
                {

                }
                private static void PrintYellowText(string v)
                {

                }
                //Main 화면
                static void Main(string[] args)
                {
                    Title = "스파르타 던전";
                    WriteLine("스파르타 던전\n");
                    WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                    Write("이름을 입력해주세요. : ");
                    string playerName = Console.ReadLine();
                    Clear();
                    WriteLine(playerName + " 님 환영합니다. ");

                    // 두번쨰 게임 시작 화면 

                    WriteLine("게임을 시작합니다.");
                    WriteLine("1: 전사 / 2: 마법사 / 3: 궁수 ");
                    Write("원하는 직업을 입력하세요: ");
                    string job = Console.ReadLine();

                    switch (job)
                    {
                        case "전사":
                            Console.WriteLine("전사를 선택하셨습니다.");
                            Console.ReadLine();
                            player = new Player(playerName, job, 1, 500, 600, 2000, 1000);
                            break;
                        case "마법사":
                            Console.WriteLine("마법사를 선택하셨습니다.");
                            Console.ReadLine();
                            player = new Player(playerName, job, 1, 400, 700, 1800, 1500);
                            break;
                        case "궁수":
                            Console.WriteLine("궁수를 선택하셨습니다.");
                            Console.ReadLine();
                            player = new Player(playerName, job, 1, 500, 750, 2200, 1000);
                            break;
                        default:
                            Console.WriteLine("올바른 값을 입력해주세요.");
                            Console.ReadLine();
                            break;

                    }

                    //세번쨰 게임 화면 (상태, 인벤토리, 상점) 
                    Clear();
                    WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                    WriteLine("1.상태보기 ");
                    WriteLine("2.인벤토리 ");
                    WriteLine("3.상점 \n ");

                    WriteLine("원하는 행동을 선택해주세요.");
                    Write(">>");
                    string inputKey = Console.ReadLine();
                    NewMethod(playerName, inputKey);
                }

                private static void NewMethod(string playerName, string inputKey)
                {


                    //네번째 게임 화면 ( 상태, 인벤토리, 상점 선택 메세지)
                    switch (inputKey)
                    {
                        case "1":
                            Console.WriteLine("상태보기를 선택하셨습니다.");

                            //스레드 이용해서 ,, 몇초 후 화면 전환
                            //상태보기 메서드 불러오기 

                            Console.Clear();
                            Console.WriteLine("상태보기");
                            Console.WriteLine("");
                            Console.WriteLine("캐릭터의 정보가 표기됩니다.");

                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Lv :" + player.playerLevel);
                            Console.WriteLine("이름 :" + player.playerName);
                            Console.WriteLine("직업 :" + player.playerJob);
                            Console.WriteLine("");
                            Console.WriteLine("공격력 :" + player.baseAtk);
                            Console.WriteLine("체력 :" + player.playerHp);
                            Console.WriteLine("Gold :" + player.playerGold);
                            Console.WriteLine("--------------------------------");

                            break;
                        case "2":
                            Console.WriteLine("인벤토리를 선택하셨습니다.");

                            //스레드 이용해서 ,, 몇초 후 화면 전환
                            //상태보기 메서드 불러오기 

                            Console.Clear();
                            Console.WriteLine("인벤토리");
                            Console.WriteLine("");
                            Console.WriteLine(playerName + " 가 보유한 아이템이 표시됩니다.");

                            //보유한게 없음
                            //아이템의 이름 + 개수 (포션포함, 전체 장비, 능력치 구현)
                            //아이템 장착 부분은 딕셔너리로 
                            //제이슨을 이용한 저장 (선택적)
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("상점");
                            Console.WriteLine("");
                            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("[보유 골드]");
                            Console.WriteLine($"Gold : {player.playerGold}");
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("===== [아이템 목록] =====");
                            Console.WriteLine("1. HP 회복약 (100 골드)");
                            Console.WriteLine("2. MP 회복약 (100 골드)");
                            Console.WriteLine("3. 공격력 증가약 (500 골드)");
                            Console.WriteLine("4. 방어력 증가약 (500 골드)");
                            Console.WriteLine("5. 종료");
                            static void PurchaseItem(int index)
                            {
                                // index가 유효한지 확인
                                if (index < 0 || index >= Item.Count)
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                    return;
                                }

                                // 플레이어의 골드를 확인
                                int gold = player.playerGold;
                                if (gold
                                     >= Item[index].price)
                                {
                                    return;
                                }
                                Console.WriteLine("골드가 부족합니다.");
                                return;

                            }
                            break;
                        default:
                            Console.WriteLine("올바른 값을 입력해주세요.");
                            break;

                    }
                }
            }






        }
        }
    }

        
    

        
       
    

   
  

