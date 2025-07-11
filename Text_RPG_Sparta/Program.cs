using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static Text_RPG_Sparta.Program;

namespace Text_RPG_Sparta
{
    public static class Program
    {
        public enum ItemType { Weapon, Armor }

        static List<Weapon> shopWeapon = new List<Weapon> { };
        static List<Armor> shopArmor = new List<Armor> { };
        static string Desvoid = "\n                                                                        ";
        static Weapon oldSword = new Weapon
        {
            Name = "낡은 검",
            IncreaseAtk = 2,
            Type = ItemType.Weapon,
            Price = 600,
            ShopDescription = $"우리 집에서 쓰던 식칼인데..날이 좀 무뎌.. 베일까봐 무서워서..",
            Description = $"우리 집에서 쓰던 식칼인데..날이 좀 무뎌.. 베일까봐 무서워서.."
        };
        static Armor noviceArmor = new Armor
        {
            Name = "수련자 갑옷",
            IncreaseDef = 5,
            Type = ItemType.Armor,
            Price = 1000,
            ShopDescription = $"오빠가 입던 맨투맨 티인데..두꺼우니까 이거라도 입으면 나을거야.",
            Description = $"오빠가 입던 맨투맨 티인데..두꺼우니까 이거라도 입으면 나을거야."
        };

        static Player player = new Player();


        public static void Main()
        {
            Console.Title = "Text_RPG_SpartaDungeon";
            Console.SetBufferSize(120, 30);
            Console.SetWindowSize(120, 30);
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.CursorVisible = false;

            shopWeapon.Add(oldSword);
            shopArmor.Add(noviceArmor);

            ShowVillageMenu();

        }
        static void MidText(string text)
        {
            double paddingF = (Console.WindowWidth - text.Length * 1.4) / 2;
            int padding = (int)paddingF;
            Console.WriteLine(new string(' ', padding) + text);
        }

        static void LeftText(string text)
        {
            int padding = (Console.WindowWidth - 50) / 2;
            Console.WriteLine(new string(' ', padding) + text);
        }
        static void MidShopText(string text)
        {
            double paddingF = (Console.WindowWidth - text.Length) / 2;
            int padding = (int)paddingF;
            Console.WriteLine(new string(' ', padding) + text);
        }

        static void LeftShopText(string text)
        {
            int padding = (Console.WindowWidth - 100) / 2;
            Console.Write(new string(' ', padding) + text);
        }
        static void ShowVillageMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n");
                MidText("스파르타 마을에 오신 것을 환영합니다!");
                Console.WriteLine("\n\n");
                LeftText("1. 스태창\n\n");
                LeftText("2. 인벤토리\n\n");
                LeftText("3. 상점\n\n");
                LeftText("4. 던전입장\n\n");
                LeftText("5. 휴식하기");
                Console.SetCursorPosition(0, 25);
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": ShowStatus(); break;
                    case "2": InventoryMenu(); break;
                    case "3": ShopMenu(); break;
                    case "4": DungeonMenu(); break;
                    case "5": Rest(); break;
                    default:
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowStatus()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n");
                MidText("       [스 태 창]");
                MidText("      스파르타 상태창입니다.\n");
                LeftText($"Lv. {player.Level}\n");
                LeftText($"{player.Name} ({player.Job})\n");
                LeftText($"공격력: {player.GetAtk()}\n");
                LeftText($"방어력: {player.GetDef()}\n");
                LeftText($"체력: {player.Hp}\n");
                LeftText($"Gold: {player.Coin}\n\n\n\n\n");
                LeftText("0. 나가기\n\n\n");
                Console.SetCursorPosition(0, 25);
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }
        static void InventoryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n");
                MidShopText(" [인 벤 토 리]\n");
                MidShopText("\b아이템  목록");
                Console.SetCursorPosition(0, 23);
                MidText("       1. 장비 메뉴     0. 돌아가기");
                foreach (var item in player.Inventory)
                {
                    LeftShopText($"- {item.Name} (공격력: {item.IncreaseAtk}, 방어력: {item.IncreaseDef}, 가격: {item.Price})");
                }
                Console.SetCursorPosition(0, 25);
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EquipmentMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void EquipmentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n");

                MidShopText("장비 메뉴\n");

                Console.Write("장착할 아이템을 선택하세요.\n\n");
                foreach (var item in player.Inventory)
                {
                    Console.WriteLine($"- {item.GetDisplayName()} (공격력: {item.IncreaseAtk}, 방어력: {item.IncreaseDef})");
                }
                Console.WriteLine("\n0. 돌아가기");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= player.Inventory.Count)
                {
                    if (choice == 0)
                    {
                        break; // 장비 메뉴 나가기
                    }
                    var selectedItem = player.Inventory[choice - 1];
                    if (selectedItem.IsEquipped)
                    {
                        selectedItem.IsEquipped = false;
                        Console.WriteLine($"아이템 '{selectedItem.Name}'의 장착을 해제했습니다.");
                    }
                    else
                    {
                        selectedItem.IsEquipped = true;
                        Console.WriteLine($"아이템 '{selectedItem.Name}'을(를) 장착했습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ShopMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                MidShopText("     상 점\n");
                MidText("  필요한 아이템을 얻을 수 있는 상점입니다.\n");
                MidText("       [아이템  목록]\n");

                foreach (var item in shopWeapon)
                {
                    LeftShopText($"-  {item.GetDisplayName()}");
                    Console.SetCursorPosition(29, Console.CursorTop);
                    Console.Write($"| 공격력: {item.IncreaseAtk}");
                    Console.SetCursorPosition(42, Console.CursorTop);

                    if (item.IsPurchased)
                    { Console.Write($"| (구매완료)"); }
                    else if (!item.IsPurchased)
                    { Console.Write($"| {item.Price} G"); }

                    Console.SetCursorPosition(51, Console.CursorTop);
                    Console.Write($"| {item.ShopDescription}\n\n");
                }
                foreach (var item in shopArmor)
                {
                    LeftShopText($"-  {item.GetDisplayName()}");
                    Console.SetCursorPosition(29, Console.CursorTop);
                    Console.Write($"| 방어력: {item.IncreaseDef}");
                    Console.SetCursorPosition(42, Console.CursorTop);

                    if (item.IsPurchased)
                    { Console.Write($"| (구매완료)"); }
                    else if (!item.IsPurchased)
                    { Console.Write($"| {item.Price} G"); }

                    Console.SetCursorPosition(51, Console.CursorTop);
                    Console.Write($"| {item.ShopDescription}\n\n");
                }

                Console.SetCursorPosition(0, 22);
                MidShopText($"[보유 골드]       {player.Coin} G\n");
                LeftText(" 1. 아이템 구매     2. 아이템 판매     0. 돌아가기\n");
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                string input = Console.ReadLine();

                if (input == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        MidShopText("     상 점\n");
                        MidText("구매할 아이템을 선택하세요.\n");
                        MidText("       [아이템  목록]\n");

                        int number = 1;
                        foreach (var item in shopWeapon)
                        {
                            item.ShopIndex = number;
                            LeftShopText($"{number}. {item.GetDisplayName()}");
                            Console.SetCursorPosition(29, Console.CursorTop);
                            Console.Write($"| 공격력: {item.IncreaseAtk}");
                            Console.SetCursorPosition(42, Console.CursorTop);

                            if (item.IsPurchased)
                            { Console.Write($"| (구매완료)"); }
                            else if (!item.IsPurchased)
                            { Console.Write($"| {item.Price} G"); }

                            Console.SetCursorPosition(51, Console.CursorTop);
                            Console.Write($"| {item.ShopDescription}\n\n");
                            number++;
                        }
                        foreach (var item in shopArmor)
                        {
                            item.ShopIndex = number;
                            LeftShopText($"{number}. {item.GetDisplayName()}");
                            Console.SetCursorPosition(29, Console.CursorTop);
                            Console.Write($"| 방어력: {item.IncreaseDef}");
                            Console.SetCursorPosition(42, Console.CursorTop);

                            if (item.IsPurchased)
                            { Console.Write($"| (구매완료)"); }
                            else if (!item.IsPurchased)
                            { Console.Write($"| {item.Price} G"); }

                            Console.SetCursorPosition(51, Console.CursorTop);
                            Console.Write($"| {item.ShopDescription}\n");
                            number++;
                        }
                        Console.SetCursorPosition(0, 22);
                        MidShopText($"[보유 골드]       {player.Coin} G\n");
                        MidShopText("\b\b\b\b\b* 구매할 상품의 번호를 입력하세요.    0. 돌아가기\n");
                        MidText("원하시는 행동을 입력해주세요.\n");
                        LeftText("▶▶");
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        string buyInput = Console.ReadLine();

                        if (buyInput == "0")
                        {
                            break;
                        }
                        if (int.TryParse(buyInput, out int buyChoice) && buyChoice > 0 && buyChoice <= shopWeapon.Count + shopArmor.Count)
                        {
                            Item itemToBuy = null;
                            foreach (var weapon in shopWeapon)
                            {
                                if (weapon.ShopIndex == buyChoice)
                                {
                                    itemToBuy = weapon;
                                    break;
                                }
                            }
                            if (itemToBuy == null)
                            {
                                foreach (var armor in shopArmor)
                                {
                                    if (armor.ShopIndex == buyChoice)
                                    {
                                        itemToBuy = armor;
                                        break;
                                    }
                                }
                            }
                            if (itemToBuy != null)
                            {
                                if (itemToBuy.IsPurchased)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Console.ReadKey();
                                }
                                else if (player.Coin >= itemToBuy.Price)
                                {
                                    player.Inventory.Add(itemToBuy);
                                    player.Coin -= itemToBuy.Price;
                                    itemToBuy.IsPurchased = true;
                                    Console.WriteLine($"아이템 '{itemToBuy.Name}'을(를) 구매했습니다. 현재 골드: {player.Coin} G");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    MidShopText("판매할 아이템을 선택하세요.\n");
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        var item = player.Inventory[i];
                        Console.WriteLine($"{i + 1}. {item.GetDisplayName()} (공격력: {item.IncreaseAtk}, 방어력: {item.IncreaseDef}, 가격: {item.Price})");
                    }
                    Console.WriteLine("0. 돌아가기");
                    Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                    string sellInput = Console.ReadLine();
                    if (sellInput == "0")
                    {
                        continue;
                    }
                    if (int.TryParse(sellInput, out int sellChoice) && sellChoice > 0 && sellChoice <= player.Inventory.Count)
                    {
                        var itemToSell = player.Inventory[sellChoice - 1];
                        player.Coin += itemToSell.Price;
                        player.Inventory.RemoveAt(sellChoice - 1);
                        Console.WriteLine($"아이템 '{itemToSell.Name}'을(를) 판매했습니다. 현재 골드: {player.Coin} G");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                else if (input == "0")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }

        static void DungeonMenu()
        {
            bool isDungeonEntered = false;
            while (!isDungeonEntered)
            {
                Console.Clear();
                Console.WriteLine("\n");
                MidText("페르시아인이 도사리고있는 던전입니다.\n\n\n");
                LeftText("1. 쉬운 던전\n\n");
                LeftText("2. 보통 던전\n\n");
                LeftText("3. 어려운 던전\n\n\n\n\n\n\n\n");
                LeftText("0. 돌아가기\n\n\n");
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("쉬운 던전에 입장합니다.");
                        Console.ReadKey(true);
                        isDungeonEntered = true;
                        Dungeon easyDungeon = new Dungeon
                        {
                            Name = "쉬운 던전",
                            DefNeed = 5,
                            HpDecrease = 0,
                            Description = "페르시아인이 도사리고 있는 쉬운 던전입니다. 권장 방어력: 5"
                        };
                        easyDungeon.EnterDungeon(1);
                        break;

                    case "2":
                        Console.WriteLine("보통 던전에 입장합니다.");
                        Console.ReadKey(true);
                        isDungeonEntered = true;
                        Dungeon nomalDungeon = new Dungeon
                        {
                            Name = "보통 던전",
                            DefNeed = 10,
                            HpDecrease = 0,
                            Description = "페르시아인이 도사리고 있는 보통 던전입니다. 권장 방어력: 10"
                        };
                        nomalDungeon.EnterDungeon(2);
                        break;

                    case "3":
                        Console.WriteLine("어려운 던전에 입장합니다.");
                        Console.ReadKey(true);
                        isDungeonEntered = true;
                        Dungeon hardDungeon = new Dungeon
                        {
                            Name = "어려운 던전",
                            DefNeed = 15,
                            HpDecrease = 0,
                            Description = "페르시아인이 도사리고 있는 어려운 던전입니다. 권장 방어력: 15"
                        };
                        hardDungeon.EnterDungeon(3);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Rest()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");

            Console.WriteLine("\n\n\n");
            Console.Write("휴식 중입니다. 체력을 회복합니다.\n\n\n");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("·\n\n");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("·\n\n");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("·\n\n");
            System.Threading.Thread.Sleep(500);

            player.Hp = player.MaxHp;
            Console.Write($"체력이 {player.MaxHp}으로 회복되었습니다.\n\n");
            Console.Write("휴식이 끝났습니다.\n\n");
            Console.WriteLine("\n\n\n");
            Console.Write("메뉴로 돌아가려면 아무 키나 누르세요.");
            Console.ReadKey();
        }
    }
    public class Player
    {
        public string Name { get; set; } = "막시무스";
        public string Job { get; set; } = "전사";
        public int Level { get; set; } = 1;
        public int BaseAtk { get; set; } = 10;
        public int BaseDef { get; set; } = 5;
        public int MaxHp { get; set; } = 100;
        public int Hp { get; set; } = 100;
        public int Coin { get; set; } = 1500;
        public List<Item> Inventory { get; set; } = new List<Item>();

        public int GetAtk() => BaseAtk + Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Weapon).Sum(i => i.IncreaseAtk);
        public int GetDef() => BaseDef + Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Armor).Sum(i => i.IncreaseDef);
    }
    public abstract class Item
    {
        public string Name { get; set; }
        public int ShopIndex { get; set; }
        public string Description { get; set; }
        public string ShopDescription { get; set; }
        public int IncreaseAtk { get; set; }
        public int IncreaseDef { get; set; }
        public ItemType Type { get; set; }
        public int Price { get; set; }
        public string PriceString => Price + " G";
        public bool IsEquipped { get; set; } = false;
        public bool IsPurchased { get; set; } = false;

        public string GetDisplayName() => (IsEquipped ? "[E]" : "") + Name;
    }
    public class Weapon : Item
    {
        public string Name { get; set; }
        public int ShopIndex { get; set; }
        public string Description { get; set; }
        public string ShopDescription { get; set; }
        public int IncreaseAtk { get; set; }
        public int IncreaseDef { get; set; }
        public ItemType Type { get; set; } = ItemType.Weapon;
        public int Price { get; set; }
        public bool IsEquipped { get; set; } = false;
        public bool IsPurchased { get; set; } = false;
        public string GetDisplayName() => (IsEquipped ? "[E]" : "") + Name;
    }
    public class Armor : Item
    {
        public string Name { get; set; }
        public int ShopIndex { get; set; }
        public string Description { get; set; }
        public string ShopDescription { get; set; }
        public int IncreaseAtk { get; set; }
        public int IncreaseDef { get; set; }
        public ItemType Type { get; set; } = ItemType.Armor;
        public int Price { get; set; }
        public bool IsEquipped { get; set; } = false;
        public bool IsPurchased { get; set; } = false;
        public string GetDisplayName() => (IsEquipped ? "[E]" : "") + Name;
    }

    public class Dungeon
    {
        public int DefNeed { get; set; }
        public int HpDecrease { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void EnterDungeon(int difficulty)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < (Console.WindowWidth / 3) + 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write($"던전 이름: {Name} | 권장 방어력: {DefNeed}\n\n");
            for (int i = 0; i < (Console.WindowWidth / 3) + 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write($"설명: {Description}\n\n");
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < (Console.WindowWidth / 2.7) + 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write("던전에 입장하려면 아무 키나 누르세요.");
            Console.ReadKey();
        }
    }
}