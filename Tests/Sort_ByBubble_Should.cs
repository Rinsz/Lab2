using System.Linq;
using BubbleSort;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class Sort_ByBubble_Should
    {
        public static string fullText;
        public static string[] strings;
        
        [SetUp]
        public void SetUp()
        {
            strings = new[]
            {
                "Дядя Жора заперся в толчке и не выходил оттуда уже целых два часа Сначала его мучил дикий запор.",
                "Он пытался выдавить личинку, но что-то шло не по плану. Какуля камнем застряла между булок дяди Жоры.",
                "Казалось, что пробить её можно только тяжёлым молотом. Дядя Жора пробовал протолкнуть какаху пальцем, попутно сделав себе массаж простаты.",
                "Но и это не помогало. Тогда он взял вантуз и попытался выкурить личинку при его помощи.",
                "Какуля никак не поддавалась, и дядя Жора вспомнил, что у него в туалете лежал освежитель воздуха.",
                "Металлическая бутыль оказалась в очке нашего героя, чем доставила последнему массу неудобств.",
                "Дядя Жора начал елозить жопой по кафельному полу и случилось чудо - днище было пробито.",
                "Всё содержимое кишечника и прямой кишки оказалось на полу, впрочем вместе с прямой кишкой.",
                "Дядя Жора усиленно пытался запихнуть вылезший геморрой обратно в очелло, но все его попытки были тщетны - днище нужно было зашивать.",
                "Подоспевшая бригада медиков хотели оказать помощь, но вымазанный в крови и фекалиях дядя Жора, имел отталкивающий вид.",
                "Но вся история закончилась хорошо: дядю Жору доставили в больницу и зашили ему очко :)"
            };

            fullText = string.Join(' ', strings);
        }
        
        [Test]
        public void SortWordsCorrectly()
        {
            var words = fullText.Split(new[] {' ', ',', '.', '!', '?', '-', ':', ';', '(', ')', '\'', '\"'});

            Sort<string>.ByBubble(words).Should().ContainInOrder(words.OrderBy(x => x));
            Sort<string>.ByBubble(words,SortOrder.Descending).Should().ContainInOrder(words.OrderByDescending(x => x));
        }
        
        [Test]
        public void SortStringsCorrectly()
        {
            Sort<string>.ByBubble(strings).Should().ContainInOrder(strings.OrderBy(x => x));
            Sort<string>.ByBubble(strings, SortOrder.Descending).Should().ContainInOrder(strings.OrderByDescending(x => x));
        }
        
        [Test]
        public void SortNumbersCorrectly()
        {
            var data = new[]
            {
                7, 234, 74, 2, 3, 7, 9, 3, 5, 7, 6, 8, 0, 134, 53, 56, 84, 345, 63, 23, 62, 34, 44, 56, 43, 15, 16, 17,
                11, 10
            };

            Sort<int>.ByBubble(data).Should().ContainInOrder(data.OrderBy(x => x));
            Sort<int>.ByBubble(data,SortOrder.Descending).Should().ContainInOrder(data.OrderByDescending(x => x));
        }
    }
}