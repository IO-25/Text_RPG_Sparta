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

        static Weapon bronzeAx = new Weapon
        {
            Name = "청동 도끼",
            IncreaseAtk = 5,
            Type = ItemType.Weapon,
            Price = 1500,
            ShopDescription = $"뒷마당에서 찾았어, 손도끼라 조금 작지만.. 쓸만할거야.",
            Description = $"뒷마당에서 찾았어, 손도끼라 조금 작지만.. 쓸만할거야."
        };

        static Weapon spartanSpear = new Weapon
        {
            Name = "스파르타의 창",
            IncreaseAtk = 10,
            Type = ItemType.Weapon,
            Price = 2500,
            ShopDescription = $"전설의 스파르타 전사의 전설에 등장하는 전설의 스파르타 창.",
            Description = $"전설의 스파르타 전사의 전설에 등장하는 전설의 스파르타 창."
        };

        static Armor noviceArmor = new Armor
        {
            Name = "수련자 갑옷",
            IncreaseDef = 5,
            Type = ItemType.Armor,
            Price = 1000,
            ShopDescription = $"오빠가 입던 잠바인데..두꺼우니까 이거라도 입으면 나을거야.",
            Description = $"오빠가 입던 잠바인데..두꺼우니까 이거라도 입으면 나을거야."
        };

        static Armor castIronArmor = new Armor
        {
            Name = "무쇠 갑옷",
            IncreaseDef = 9,
            Type = ItemType.Armor,
            Price = 2000,
            ShopDescription = $"뾱뾱이랑.. 골판지..? 그걸로 뭘 하려고?",
            Description = $"뾱뾱이랑.. 골판지..? 그걸로 뭘 하려고?",
        };

        static Armor armorOfSparta = new Armor
        {
            Name = "스파르타의 갑옷",
            IncreaseDef = 15,
            Type = ItemType.Armor,
            Price = 3500,
            ShopDescription = $"전설의 스파르타 전사의 전설에 등장하는 전설의 스파르타 갑옷.",
            Description = $"전설의 스파르타 전사의 전설에 등장하는 전설의 스파르타 갑옷."
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
            shopArmor.Add(castIronArmor);
            shopWeapon.Add(bronzeAx);
            shopWeapon.Add(spartanSpear);
            shopArmor.Add(armorOfSparta);

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
            int padding = (Console.WindowWidth - 114) / 2;
            Console.Write(new string(' ', padding) + text);
        }
        static void ShowVillageMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                MidText("스파르타 마을에 오신 것을 환영합니다!");

                Console.WriteLine("\n\n");
                LeftText("1. 스태창\n\n");
                LeftText("2. 인벤토리\n\n");
                LeftText("3. 상점\n\n");
                LeftText("4. 던전입장\n\n");
                LeftText("5. 휴식하기");
                Console.SetCursorPosition(0, 25);
                Console.ForegroundColor = ConsoleColor.Yellow;
                MidText("원하시는 행동을 입력해주세요.\n");
                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                MidText("       [스 태 창]");
                MidText("      스파르타 상태창입니다.\n");
                LeftText($"Lv. {player.Level}\n");
                LeftText($"{player.Name} ({player.Job})\n");
                LeftText($"공격력: {player.GetAtk()} (+ {player.GetAdditionalAtk()})\n");
                LeftText($"방어력: {player.GetDef()} (+ {player.GetAdditionalDef()})\n");
                LeftText($"체력: {player.Hp}\n");
                LeftText($"Gold: {player.Coin}\n\n\n\n\n");
                LeftText("Enter. 나가기\n\n\n");
                Console.SetCursorPosition(0, 25);
                Console.ForegroundColor = ConsoleColor.Yellow;
                MidText("원하시는 행동을 입력해주세요.\n");
                Console.ForegroundColor = ConsoleColor.White;
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string? input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2 - 25), Console.WindowHeight / 2 - 2);
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
                Console.ForegroundColor = ConsoleColor.White;
                MidShopText("  [인 벤 토 리]\n");
                MidText("           [아 이 템  목 록]\n");

                foreach (var item in player.Inventory)
                {
                    if (item.Type == ItemType.Weapon)
                    {
                        LeftShopText($"-  {item.GetDisplayName()}");
                        Console.SetCursorPosition(25, Console.CursorTop);
                        Console.Write($"| 공격력: {item.IncreaseAtk}");
                        Console.SetCursorPosition(38, Console.CursorTop);

                        if (item.IsPurchased)
                        { Console.Write($"|(구매완료)"); }
                        else if (!item.IsPurchased)
                        { Console.Write($"| {item.Price} G"); }

                        Console.SetCursorPosition(48, Console.CursorTop);
                        Console.Write($"| {item.ShopDescription}\n\n");
                        Console.ResetColor();
                    }
                    else if (item.Type == ItemType.Armor)
                    {
                        LeftShopText($"-  {item.GetDisplayName()}");
                        Console.SetCursorPosition(25, Console.CursorTop);
                        Console.Write($"| 방어력: {item.IncreaseDef}");
                        Console.SetCursorPosition(38, Console.CursorTop);

                        if (item.IsPurchased)
                        { Console.Write($"|(구매완료)"); }
                        else if (!item.IsPurchased)
                        { Console.Write($"| {item.Price} G"); }

                        Console.SetCursorPosition(48, Console.CursorTop);
                        Console.Write($"| {item.ShopDescription}\n\n");
                    }
                }

                Console.SetCursorPosition(0, 21);
                MidText($"[보유 골드] {player.Coin} G | 그녀석들.. 통조림은 건들지 않더라.. 냄새로 구분하는 걸까?\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                MidText("       1. 장비 메뉴     Enter. 돌아가기");
                Console.SetCursorPosition(0, 25);
                MidText("원하시는 행동을 입력해주세요.\n");
                Console.ForegroundColor = ConsoleColor.White;
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EquipmentMenu();
                        break;
                    case "":
                        return;
                    default:
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2 - 5), Console.WindowHeight / 2 - 2);
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
                Console.ForegroundColor = ConsoleColor.White;
                MidShopText("   [장 비  메 뉴]\n");
                MidShopText("\b\b장착할 아이템을 선택하세요.\n");
                Console.ForegroundColor = ConsoleColor.White;

                int index = 1;
                foreach (var item in player.Inventory)
                {
                    if (item.Type == ItemType.Weapon)
                    {
                        LeftShopText($"{index}.  {item.GetDisplayName()}");
                        Console.SetCursorPosition(25, Console.CursorTop);
                        Console.Write($"| 공격력: {item.IncreaseAtk}");
                        Console.SetCursorPosition(38, Console.CursorTop);

                        if (item.IsPurchased)
                        { Console.Write($"|구매완료"); }
                        else if (!item.IsPurchased)
                        { Console.Write($"| {item.Price} G"); }

                        Console.SetCursorPosition(48, Console.CursorTop);
                        Console.Write($"| {item.ShopDescription}\n\n");
                        index++;
                    }
                    else if (item.Type == ItemType.Armor)
                    {
                        LeftShopText($"{index}.  {item.GetDisplayName()}");
                        Console.SetCursorPosition(25, Console.CursorTop);
                        Console.Write($"| 방어력: {item.IncreaseDef}");
                        Console.SetCursorPosition(38, Console.CursorTop);

                        if (item.IsPurchased)
                        { Console.Write($"|구매완료"); }
                        else if (!item.IsPurchased)
                        { Console.Write($"| {item.Price} G"); }

                        Console.SetCursorPosition(48, Console.CursorTop);
                        Console.Write($"| {item.ShopDescription}\n\n");
                        index++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, 23);
                MidText("* 장비의 번호를 입력하세요.     Enter. 돌아가기");
                Console.SetCursorPosition(0, 25);
                MidText("원하시는 행동을 입력해주세요.\n");
                LeftText("▶▶");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= player.Inventory.Count)
                {

                    var selectedItem = player.Inventory[choice - 1];
                    if (selectedItem.IsEquipped)
                    {
                        selectedItem.IsEquipped = false;
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2 - 15), Console.WindowHeight / 2 - 2);
                        Console.WriteLine($"아이템 '{selectedItem.Name}'의 장착을 해제했습니다.");
                        Console.ReadKey();
                    }
                    else
                    {
                        selectedItem.IsEquipped = true;
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 2);
                        Console.WriteLine($"아이템 '{selectedItem.Name}'을(를) 장착했습니다.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2);
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }

        static void ShopMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                MidShopText("     상 점\n");
                MidText("  필요한 아이템을 얻을 수 있는 상점입니다.\n");
                MidText("       [아이템  목록]\n");

                foreach (var item in shopWeapon)
                {
                    LeftShopText($"-  {item.GetDisplayName()}");
                    Console.SetCursorPosition(25, Console.CursorTop);
                    Console.Write($"| 공격력: {item.IncreaseAtk}");
                    Console.SetCursorPosition(38, Console.CursorTop);

                    if (item.IsPurchased)
                    { Console.Write($"| 구매완료"); }
                    else if (!item.IsPurchased)
                    { Console.Write($"| {item.Price} G"); }

                    Console.SetCursorPosition(48, Console.CursorTop);
                    Console.Write($"| {item.ShopDescription}\n\n");
                }
                foreach (var item in shopArmor)
                {
                    LeftShopText($"-  {item.GetDisplayName()}");
                    Console.SetCursorPosition(25, Console.CursorTop);
                    Console.Write($"| 방어력: {item.IncreaseDef}");
                    Console.SetCursorPosition(38, Console.CursorTop);

                    if (item.IsPurchased)
                    { Console.Write($"| 구매완료"); }
                    else if (!item.IsPurchased)
                    { Console.Write($"| {item.Price} G"); }

                    Console.SetCursorPosition(48, Console.CursorTop);
                    Console.Write($"| {item.ShopDescription}\n\n");
                }

                Console.SetCursorPosition(0, 21);
                MidShopText($"[보유 골드]       {player.Coin} G\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                LeftText(" 1. 아이템 구매     2. 아이템 판매     Enter. 돌아가기\n");
                MidText("원하시는 행동을 입력해주세요.\n");
                Console.ForegroundColor = ConsoleColor.White;
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                string input = Console.ReadLine();

                if (input == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        MidShopText("     상 점\n");
                        MidText("구매할 아이템을 선택하세요.\n");
                        MidText("       [아이템  목록]\n");
                        int number = 1;
                        foreach (var item in shopWeapon)
                        {
                            item.ShopIndex = number;
                            LeftShopText($"{number}. {item.GetDisplayName()}");
                            Console.SetCursorPosition(25, Console.CursorTop);
                            Console.Write($"| 공격력: {item.IncreaseAtk}");
                            Console.SetCursorPosition(38, Console.CursorTop);

                            if (item.IsPurchased)
                            { Console.Write($"| 구매완료"); }
                            else if (!item.IsPurchased)
                            { Console.Write($"| {item.Price} G"); }

                            Console.SetCursorPosition(48, Console.CursorTop);
                            Console.Write($"| {item.ShopDescription}\n\n");
                            number++;
                        }
                        foreach (var item in shopArmor)
                        {
                            item.ShopIndex = number;
                            LeftShopText($"{number}. {item.GetDisplayName()}");
                            Console.SetCursorPosition(25, Console.CursorTop);
                            Console.Write($"| 방어력: {item.IncreaseDef}");
                            Console.SetCursorPosition(38, Console.CursorTop);

                            if (item.IsPurchased)
                            { Console.Write($"| 구매완료"); }
                            else if (!item.IsPurchased)
                            { Console.Write($"| {item.Price} G"); }

                            Console.SetCursorPosition(48, Console.CursorTop);
                            Console.Write($"| {item.ShopDescription}\n\n");
                            number++;
                        }
                        Console.SetCursorPosition(0, 21);
                        MidShopText($"[보유 골드]       {player.Coin} G\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MidShopText("\b\b\b\b* 구매할 상품의 번호를 입력하세요.    Enter. 돌아가기\n");
                        MidText("원하시는 행동을 입력해주세요.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        LeftText("▶▶");
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        string? buyInput = Console.ReadLine();

                        if (buyInput == "")
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
                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2 - 10), Console.WindowHeight / 2 - 2);
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Console.ReadKey();
                                }
                                else if (player.Coin >= itemToBuy.Price)
                                {
                                    player.Inventory.Add(itemToBuy);
                                    player.Coin -= itemToBuy.Price;
                                    itemToBuy.IsPurchased = true;
                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2 - 25), Console.WindowHeight / 2 - 2);
                                    Console.WriteLine($"아이템 '{itemToBuy.Name}'을(를) 구매했습니다. 현재 골드: {player.Coin} G");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 2);
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadKey();
                        }
                    }
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        MidShopText("     상 점\n");
                        MidText("판매할 아이템을 선택하세요.\n");
                        MidText("       [아이템  목록]\n");
                        int number = 1;
                        foreach (var item in player.Inventory)
                        {
                            if (item.IsEquipped)
                            {
                                LeftShopText($"{number}. {item.GetDisplayName()}");
                            }
                            else
                            {
                                LeftShopText($"{number}. {item.GetDisplayName()}");
                            }
                            Console.SetCursorPosition(25, Console.CursorTop);
                            if (item.Type == ItemType.Weapon)
                            {
                                Console.Write($"| 공격력: {item.IncreaseAtk}");
                            }
                            else if (item.Type == ItemType.Armor)
                            {
                                Console.Write($"| 방어력: {item.IncreaseDef}");
                            }
                            Console.SetCursorPosition(38, Console.CursorTop);
                            if (item.IsPurchased)
                            { Console.Write($"| 구매완료"); }
                            else if (!item.IsPurchased)
                            { Console.Write($"| {item.Price} G"); }
                            Console.SetCursorPosition(48, Console.CursorTop);
                            Console.Write($"| {item.ShopDescription}\n\n");
                            number++;
                        }
                        Console.SetCursorPosition(0, 21);
                        MidShopText($"[보유 골드]       {player.Coin} G\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MidShopText("\b\b\b\b\b\b\b\b\b* 판매할 상품의 번호를 입력하세요. 판매가격은 구매가격의 85%입니다.    Enter. 돌아가기\n");
                        MidText("원하시는 행동을 입력해주세요.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        LeftText("▶▶");
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        string? sellInput = Console.ReadLine();
                        if (sellInput == "")
                        {
                            break;
                        }
                        if (int.TryParse(sellInput, out int sellChoice) && sellChoice > 0 && sellChoice <= player.Inventory.Count)
                        {
                            var itemToSell = player.Inventory[sellChoice - 1];
                            if (itemToSell.IsPurchased)
                            {
                                if (itemToSell.IsEquipped)
                                {
                                    itemToSell.IsEquipped = false;
                                    player.Coin += itemToSell.Price*0.85;
                                    player.Inventory.Remove(itemToSell);
                                    itemToSell.IsPurchased = false;

                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2 - 10), Console.WindowHeight / 2 - 2);
                                    Console.WriteLine($"아이템 '{itemToSell.Name}'을(를) 판매했습니다. 현재 골드: {player.Coin} G");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    player.Coin += itemToSell.Price*0.85;
                                    player.Inventory.Remove(itemToSell);
                                    itemToSell.IsPurchased = false;

                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2 - 25), Console.WindowHeight / 2 - 2);
                                    Console.WriteLine($"아이템 '{itemToSell.Name}'을(를) 판매했습니다. 현재 골드: {player.Coin} G");
                                    Console.ReadKey();
                                }
                                itemToSell.IsEquipped = false;
                            }

                        }
                    }
                }
                else if (input == "")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                MidText("페르시아인이 도사리고있는 던전입니다.\n\n\n");
                LeftText("1. 쉬운 던전\n\n");
                LeftText("2. 보통 던전\n\n");
                LeftText("3. 어려운 던전\n\n\n\n\n\n\n\n");
                LeftText("Enter. 돌아가기\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                MidText("원하시는 행동을 입력해주세요.\n");
                Console.ForegroundColor = ConsoleColor.White;
                LeftText("▶▶");
                Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                string? input = Console.ReadLine();
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

                    case "":
                        return;

                    default:
                        Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Rest()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2 - 7), Console.WindowHeight / 2 - 5);
            Console.Write("휴식하시겠습니까?");
            Console.WriteLine("\n\n\n");
            Console.SetCursorPosition((Console.WindowWidth / 2 - 8), Console.WindowHeight / 2 - 2);
            Console.Write("1. 휴식하기 - 500 G\n\n");
            Console.SetCursorPosition((Console.WindowWidth / 2 - 7), Console.WindowHeight / 2);
            Console.Write("Enter. 돌아가기\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 25);
            MidText("원하시는 행동을 입력해주세요.\n");
            Console.ForegroundColor = ConsoleColor.White;
            LeftText("▶▶");
            Console.SetCursorPosition((Console.WindowWidth / 3 - 2), Console.CursorTop - 1);

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (player.Hp == player.MaxHp)
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
                        MidText("이미 체력이 가득 찼습니다.");
                        Console.ReadKey();
                        break;
                    }
                    else if (player.Hp < player.MaxHp && player.Coin < 500)
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
                        MidText("골드가 부족합니다. 휴식에는 500 G가 필요합니다.");
                        Console.ReadKey();
                        break;
                    }
                    else if (player.Hp < player.MaxHp && player.Coin >= 500)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine("\n");
                        MidText("     휴식 중입니다. 체력을 회복합니다.\n\n\n");
                        System.Threading.Thread.Sleep(500);
                        MidText("            ·\n\n");
                        System.Threading.Thread.Sleep(500);
                        MidText("            ·\n\n");
                        System.Threading.Thread.Sleep(500);
                        MidText("            ·\n\n");
                        System.Threading.Thread.Sleep(500);

                        player.Hp += 100;
                        if (player.Hp > player.MaxHp)
                        {
                            player.Hp = player.MaxHp;
                            MidText($"     체력이 {player.MaxHp}으로 회복되었습니다.\n\n");
                        }
                        else
                        {
                            MidText($"     체력이 {player.Hp}으로 회복되었습니다.\n\n");
                        }
                        MidText("   휴식이 끝났습니다.");
                        Console.WriteLine("\n");
                        MidText("\b메뉴로 돌아가려면 아무 키나 누르세요.");
                        Console.ReadKey();
                        break;
                    }
                    break;
                case "":
                    return;
                    break;
                default:
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2 - 6), Console.WindowHeight / 2 - 2);
                    MidText("잘못된 입력입니다.");
                    Console.ReadKey();
                    break;
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
            public double Hp { get; set; } = 100;
            public double Coin { get; set; } = 1500;
            public List<Item> Inventory { get; set; } = new List<Item>();

            public int GetAtk() => BaseAtk + Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Weapon).Sum(i => i.IncreaseAtk);
            public int GetAdditionalAtk()
            {
                return Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Weapon).Sum(i => i.IncreaseAtk);
            }
            public int GetDef() => BaseDef + Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Armor).Sum(i => i.IncreaseDef);
            public int GetAdditionalDef()
            {
                return Inventory.Where(i => i.IsEquipped && i.Type == ItemType.Armor).Sum(i => i.IncreaseDef);
            }
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
            public double Price { get; set; }
            public string PriceString => Price + " G";
            public bool IsEquipped { get; set; } = false;
            public bool IsPurchased { get; set; } = false;
            public string GetDisplayName() => (IsEquipped ? "[E] " : "") + Name;
        }
        public class Weapon : Item
        {
            public Weapon()
            {
                Type = ItemType.Weapon;
            }
        }
        public class Armor : Item
        {
            public Armor()
            {
                Type = ItemType.Armor;
            }
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
}