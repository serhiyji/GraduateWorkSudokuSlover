﻿using GraduateWorkSudokuSlover.SudokuSloverHendler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Slover.DescriptionAlgorithms
{
    public class DescriptionsForAlgorithmSudokuSlover : GraduateWorkSudokuSlover.Expansion.SingletonClass<DescriptionsForAlgorithmSudokuSlover>
    {
        
        public Dictionary<AlgorithmSudokuSlover, string> Descriptions { get; set; }
        public DescriptionsForAlgorithmSudokuSlover()
        {
            this.Descriptions = new Dictionary<AlgorithmSudokuSlover, string>();
            this.Descriptions.Add(AlgorithmSudokuSlover.None, Description.Instance.None);
            this.Descriptions.Add(AlgorithmSudokuSlover.Full_House, Description.Instance.Full_House);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Single, Description.Instance.Naked_Single);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Single, Description.Instance.Hidden_Single);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Pair, Description.Instance.Locked_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Triple, Description.Instance.Locked_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Candidates_Type_Pointing, Description.Instance.Locked_Candidates_Type_Pointing);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Candidates_Type_Claiming, Description.Instance.Locked_Candidates_Type_Claiming);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Pair, Description.Instance.Naked_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Triple, Description.Instance.Naked_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Quadruple, Description.Instance.Naked_Quadruple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Pair, Description.Instance.Hidden_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Triple, Description.Instance.Hidden_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Quadruple, Description.Instance.Hidden_Quadruple);
        }
        public string GetDescription(AlgorithmSudokuSlover al)
        {
            return this.Descriptions.TryGetValue(al, out string description) ? description : string.Empty;
        }
    }
    internal class Description : GraduateWorkSudokuSlover.Expansion.SingletonClass<Description>
    {
        public string None = @"";
        public string Full_House = @$"
Алгоритм рішення судоку Full House (повне заповнення) - це метод, який використовується для розв'язання складних головоломок судоку, де деякі клітинки вже заповнені числами, а решта потребує визначення.
Основна ідея алгоритму полягає в тому, щоб послідовно перебрати кожну незаповнену клітинку і спробувати встановити в неї правильне число від 1 до 9. Цей процес повторюється для кожної клітинки, що не має значення.
Щоб встановити правильне число в клітинці, спочатку перевіряється, чи є воно унікальним в рядку, стовпчику та малому квадраті 3x3, до якого належить клітинка. Якщо число вже присутнє в будь-якому з цих трьох контекстів, то спробуємо інше число. Цей процес повторюється для кожного числа від 1 до 9, доки не знайдеться унікальне число для клітинки.
Коли унікальне число знайдено, воно встановлюється в клітинку, і цей процес повторюється для наступної незаповненої клітинки. Алгоритм продовжується, поки всі клітинки не будуть заповнені правильними значеннями або поки не виявиться конфлікт, коли неможливо знайти унікальне число для певної клітинки.
Алгоритм рішення судоку Full House є досить простим, але в деяких випадках може зайняти значну кількість ітерацій для знаходження правильного розв'язку. Існують також більш складні алгоритми, які використовуються для розв'язання більш складних судоку, де алгоритм Full House може не бути достатньо ефективним.";
        public string Naked_Single = @"
Алгоритм рішення судоку Naked Single (відкритий одиночний) - це простий, але ефективний метод для визначення правильного числа в клітинці на основі аналізу обмежень, накладених на інші клітинки в одному рядку, стовпчику та малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що для кожної незаповненої клітинки ми переглядаємо рядок, стовпчик і малий квадрат, до якого вона належить, і шукаємо числа, які вже присутні в цих контекстах. Якщо знайдено число, яке відсутнє в цьому списку, то це єдине можливе число для даної клітинки, і ми можемо встановити його як правильне значення.
Наприклад, якщо в рядку вже є числа 1, 3, 4 і 9, а числа 2, 5, 6, 7 і 8 відсутні, то клітинка, що має бути заповнена, має значення 2, оскільки це єдине відсутнє число в рядку.
Алгоритм Naked Single повторюється для кожної незаповненої клітинки в судоку, поки всі клітинки не будуть заповнені правильними значеннями або поки не виявиться конфлікт, коли не можна знайти жодного відповідного числа для певної клітинки.
Цей алгоритм є першим кроком в розв'язанні складних судоку, але може бути недостатнім для вирішення більш складних головоломок. У таких випадках застосовуються більш складні алгоритми, такі як Hidden Single і інші стратегії, щоб вирішити складніші логічні головоломки судоку.";
        public string Hidden_Single = @"
Алгоритм рішення судоку Hidden Single (прихований одиночний) - це ефективний метод, який використовується для визначення правильного числа в клітинці шляхом аналізу обмежень, накладених на інші клітинки в одному рядку, стовпчику та малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що для кожного числа від 1 до 9 ми переглядаємо рядок, стовпчик і малий квадрат, до якого належить клітинка, і шукаємо місця, де це число може бути розміщене лише в одній клітинці. Якщо знайдено таку клітинку, то це означає, що вона має бути заповнена цим числом.
Наприклад, якщо у рядку є п'ять чисел 1, але тільки одна клітинка має можливість прийняти число 1, то ми знаємо, що ця клітинка повинна бути заповнена значенням 1.
Алгоритм Hidden Single повторюється для кожного числа від 1 до 9 і для кожного рядка, стовпця та малого квадрата, поки всі клітинки не будуть заповнені правильними значеннями або поки не виявиться конфлікт, коли неможливо знайти жодне відповідне число для певної клітинки.
Алгоритм Hidden Single є потужним інструментом для розв'язання складних судоку, оскільки він може виявляти скриті обмеження і допомагати встановити значення для клітинок, які інші простіші алгоритми не змогли б вирішити. Комбінація різних методів розв'язання, включаючи Naked Single, Hidden Single та інші стратегії, допомагає вирішити навіть найскладніші судоку головоломки.";
        public string Locked_Pair = @"
Алгоритм рішення судоку Locked Pair (закрита пара) - це метод, який використовується для виявлення і встановлення правильного значення в клітинках на основі залежностей між парою чисел і двома клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо дві клітинки в одному рядку, стовпчику або малому квадраті 3x3, які можуть приймати тільки два специфічних числа. Ці два числа утворюють закриту пару. Іншими словами, в інших клітинках рядка, стовпчика або малого квадрата ці числа не можуть бути присутніми.
Коли така закрита пара знайдена, ми можемо вважати, що в інших клітинках цього рядка, стовпчика або малого квадрата ці два числа не можуть бути присутніми. Таким чином, ми можемо видалити ці два числа як варіанти з інших клітинок відповідного рядка, стовпця або малого квадрата.
Цей процес допомагає зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Після застосування алгоритму Locked Pair можна продовжити з іншими методами розв'язання, такими як Naked Single або Hidden Single, для знаходження нових закритих пар і отримання більше інформації для заповнення судоку.
Алгоритм Locked Pair є важливою складовою частиною розв'язання складних судоку, оскільки він дозволяє виявляти скриті залежності між клітинками і виключати певні значення з інших клітинок. Комбінація різних методів розв'язання, включаючи Locked Pair, Naked Single, Hidden Single та інші стратегії, допомагає знайти оптимальний шлях до розв'язання судоку головоломки.";
        public string Locked_Triple = @"
Алгоритм рішення судоку Locked Triple (закрита трійка) - це метод, який використовується для визначення та встановлення правильних значень в клітинках на основі залежностей між трьома числами і трьома клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо трійку клітинок в одному рядку, стовпчику або малому квадраті, які можуть приймати тільки три певних числа. Ці три числа утворюють закриту трійку. Іншими словами, в інших клітинках рядка, стовпчика або малого квадрата ці числа не можуть бути присутніми.
Коли така закрита трійка знайдена, ми можемо вважати, що в інших клітинках цього рядка, стовпця або малого квадрата ці три числа не можуть бути присутніми. Таким чином, ми можемо видалити ці три числа як варіанти з інших клітинок відповідного рядка, стовпця або малого квадрата.
Цей процес допомагає зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Після застосування алгоритму Locked Triple можна продовжити з іншими методами розв'язання, такими як Naked Single або Hidden Single, для знаходження нових закритих трійок і отримання більше інформації для заповнення судоку.
Алгоритм Locked Triple є потужним інструментом для розв'язання складних судоку, оскільки він дозволяє виявляти скриті залежності між клітинками і виключати певні значення з інших клітинок. Комбінація різних методів розв'язання, включаючи Locked Triple, Naked Single, Hidden Single та інші стратегії, допомагає знайти оптимальний шлях до розв'язання складних судоку головоломки.";
        public string Locked_Candidates_Type_Pointing = @"
Алгоритм рішення судоку Locked Candidates Type Pointing (закриті кандидати типу вказування) - це метод, який використовується для визначення та встановлення правильного значення в клітинках на основі залежностей між кандидатами та групами клітинок в одному рядку або стовпчику.
Основна ідея алгоритму полягає в тому, що ми шукаємо кандидата, який може бути присутнім лише в одній групі клітинок (рядку або стовпчику), але знаходиться в більшому малому квадраті. Це означає, що кандидат повинен бути встановлений в клітинках, які належать до тієї ж самої групи, але не знаходяться в тому самому малому квадраті, де він знаходиться.
Якщо такий закритий кандидат знайдений, ми можемо вважати, що він не може бути присутнім в інших клітинках тієї ж самої групи, які належать до того ж самого малого квадрата. Таким чином, ми можемо видалити цей кандидат з інших клітинок групи, збільшуючи точність розв'язання судоку.
Алгоритм Locked Candidates Type Pointing може бути застосований як до рядків, так і до стовпчиків. В обох випадках ми шукаємо кандидатів, які закріплені в одній групі (рядку або стовпчику), але знаходяться в більшому малому квадраті. Застосування цього алгоритму дозволяє зменшити кількість доступних варіантів для інших клітинок групи і спростити подальші кроки розв'язання судоку.
Алгоритм Locked Candidates Type Pointing є важливою стратегією для ефективного розв'язання складних судоку, оскільки він дозволяє виявляти та виключати певні кандидати залежно від їхнього розташування в малому квадраті та відповідній групі клітинок. Комбінація різних методів розв'язання, включаючи Locked Candidates Type Pointing, Naked Single, Hidden Single та інші, допомагає досягти успішного розв'язання судоку головоломки.";
        public string Locked_Candidates_Type_Claiming = @"
Алгоритм рішення судоку Locked Candidates Type Claiming (закриті кандидати типу претендування) - це метод, який використовується для виявлення та встановлення правильного значення в клітинках на основі залежностей між кандидатами та малими квадратами в одному рядку або стовпчику.
Основна ідея алгоритму полягає в тому, що ми шукаємо кандидата, який може бути присутнім тільки в одному малому квадраті в межах одного рядка або стовпчика. Це означає, що цей кандидат ""претендує"" на зайняття конкретної позиції в межах рядка або стовпчика, і не може бути присутнім в інших маленьких квадратах, що належать до цього рядка або стовпчика.
Коли такий закритий кандидат знайдений, ми можемо встановити його значення в клітинках малого квадрата, де він претендує на присутність. Оскільки ми впевнені, що цей кандидат може бути присутнім тільки в одному малому квадраті, ми можемо виключити його з інших клітинок, що належать до цього ж рядка або стовпчика.
Застосування алгоритму Locked Candidates Type Claiming допомагає зменшити кількість доступних варіантів для інших клітинок малого квадрата і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків. В обох випадках, ми шукаємо кандидатів, які ""претендують"" на присутність тільки в одному малому квадраті.
Алгоритм Locked Candidates Type Claiming є важливою стратегією для ефективного розв'язання складних судоку, оскільки він дозволяє виявляти та виключати певні кандидати залежно від їхнього розташування в малому квадраті та відповідному рядку або стовпчику. Комбінація різних методів розв'язання, включаючи Locked Candidates Type Claiming, Naked Single, Hidden Single та інші, допомагає досягти успішного розв'язання судоку головоломки.";
        public string Naked_Pair = @"
Алгоритм рішення судоку Naked Pair (відкрита пара) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між парами кандидатів та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо дві клітинки в одному рядку, стовпчику або малому квадраті, в яких можуть бути лише два певних кандидати. Ці два кандидати утворюють відкриту пару. Оскільки ці два кандидати можуть займати тільки ці дві клітинки, ми можемо виключити їх з інших кандидатів у цьому рядку, стовпчику або малому квадраті.
Коли відкрита пара знайдена, ми можемо вважати, що інші кандидати, які містяться в цих двох клітинках, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Naked Pair дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати залежно від їхнього розташування в парі клітинок.
Алгоритм Naked Pair є важливою стратегією для ефективного розв'язання судоку, оскільки дозволяє виявляти і виключати певні кандидати, що присутні в відкритій парі, з інших клітинок рядка, стовпчика або малого квадрата. Комбінація різних методів розв'язання, включаючи Naked Pair, Hidden Single, Locked Candidates та інші, сприяє успішному розв'язанню складних судоку головоломок.";
        public string Naked_Triple = @"
Алгоритм рішення судоку Naked Triple (відкрита трійка) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між трійкою кандидатів та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо три клітинки в одному рядку, стовпчику або малому квадраті, в яких можуть бути лише три певних кандидати. Ці три кандидати утворюють відкриту трійку. Оскільки ці три кандидати можуть займати тільки ці три клітинки, ми можемо виключити їх з інших кандидатів у цьому рядку, стовпчику або малому квадраті.
Коли відкрита трійка знайдена, ми можемо вважати, що інші кандидати, які містяться в цих трьох клітинках, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Naked Triple дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати залежно від їхнього розташування в трійці клітинок.
Алгоритм Naked Triple є важливою стратегією для ефективного розв'язання складних судоку, оскільки дозволяє виявляти і виключати певні кандидати, зменшуючи кількість можливих варіантів для клітинок і спрощуючи подальші кроки розв'язання. Комбінація різних методів розв'язання, включаючи Naked Triple, Hidden Single, Locked Candidates та інші, допомагає досягти успішного розв'язання судоку головоломок.";
        public string Naked_Quadruple = @"
Алгоритм рішення судоку Naked Quadruple (відкрита четвірка) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між чотирма кандидатами та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо чотири клітинки в одному рядку, стовпчику або малому квадраті, в яких можуть бути лише чотири певних кандидати. Ці чотири кандидати утворюють відкриту четвірку. Оскільки ці чотири кандидати можуть займати тільки ці чотири клітинки, ми можемо виключити їх з інших кандидатів у цьому рядку, стовпчику або малому квадраті.
Коли відкрита четвірка знайдена, ми можемо вважати, що інші кандидати, які містяться в цих чотирьох клітинках, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Naked Quadruple дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати залежно від їхнього розташування в четвірці клітинок.
Алгоритм Naked Quadruple є важливою стратегією для ефективного розв'язання складних судоку, оскільки дозволяє виявляти і виключати певні кандидати, що допомагає зменшити кількість можливих варіантів для клітинок і прискорює процес розв'язання головоломки.";
        public string Hidden_Pair = @"
Алгоритм рішення судоку Hidden Pair (прихована пара) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між парами кандидатів та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо два кандидати, які можуть займати лише дві клітинки в одному рядку, стовпчику або малому квадраті. Ці два кандидати утворюють приховану пару. Оскільки ці два кандидати можуть бути присутніми тільки в цих двох клітинках, ми можемо виключити інші кандидати з цих двох клітинок.
Коли прихована пара знайдена, ми можемо вважати, що інші кандидати, які не входять до цієї пари, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Hidden Pair дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати, що покращує ефективність розв'язання складних судоку головоломок.
Алгоритм Hidden Pair є важливою стратегією для успішного розв'язання судоку, оскільки дозволяє виявляти і виключати певні кандидати, що допомагає збільшити точність і швидкість розв'язання головоломки.";
        public string Hidden_Triple = @"
Алгоритм рішення судоку Hidden Triple (прихована трійка) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між трійкою кандидатів та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо трійку кандидатів, які можуть займати лише три клітинки в одному рядку, стовпчику або малому квадраті. Ці трійка кандидатів утворюють приховану трійку. Оскільки ці трійка кандидатів можуть бути присутніми тільки в цих трьох клітинках, ми можемо виключити інші кандидати з цих трьох клітинок.
Коли прихована трійка знайдена, ми можемо вважати, що інші кандидати, які не входять до цієї трійки, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Hidden Triple дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати, що покращує ефективність розв'язання складних судоку головоломок.
Алгоритм Hidden Triple є важливою стратегією для успішного розв'язання судоку, оскільки дозволяє виявляти і виключати певні кандидати, що спрощує процес розв'язання та допомагає знайти правильні значення для клітинок.";
        public string Hidden_Quadruple = @"
Алгоритм рішення судоку Hidden Quadruple (прихована четвірка) - це метод, який використовується для виявлення та встановлення правильних значень в клітинках на основі залежностей між чотирма кандидатами та відповідними клітинками в одному рядку, стовпчику або малому квадраті 3x3.
Основна ідея алгоритму полягає в тому, що ми шукаємо чотири кандидати, які можуть займати лише чотири клітинки в одному рядку, стовпчику або малому квадраті. Ці чотири кандидати утворюють приховану четвірку. Оскільки ці чотири кандидати можуть бути присутніми тільки в цих чотирьох клітинках, ми можемо виключити інші кандидати з цих чотирьох клітинок.
Коли прихована четвірка знайдена, ми можемо вважати, що інші кандидати, які не входять до цієї четвірки, не можуть бути присутніми в інших клітинках рядка, стовпчика або малого квадрата. Таким чином, ми можемо видалити ці кандидати з інших клітинок відповідного рядка, стовпчика або малого квадрата.
Алгоритм Hidden Quadruple дозволяє зменшити кількість доступних варіантів для інших клітинок і спрощує подальші кроки розв'язання судоку. Цей метод може бути застосований як до рядків, так і до стовпчиків або малих квадратів. Застосування цього алгоритму допомагає виявляти та виключати певні кандидати, що покращує ефективність розв'язання складних судоку головоломок.
Алгоритм Hidden Quadruple є важливою стратегією для успішного розв'язання судоку, оскільки дозволяє виявляти і виключати певні кандидати, що спрощує процес розв'язання та допомагає знайти правильні значення для клітинок.";
    }
}
