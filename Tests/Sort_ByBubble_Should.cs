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
                "Сортировка простыми обменами, сортировка пузырьком (англ. bubble sort) - простой алгоритм сортировки.",
                "Для понимания и реализации этот алгоритм - простейший, но эффективен он лишь для небольших массивов.",
                "Алгоритм считается учебным и практически не применяется вне учебной литературы,",
                "вместо него на практике применяются более эффективные алгоритмы сортировки.",
                "В то же время метод сортировки обменами лежит в основе некоторых более совершенных алгоритмов, таких как шейкерная сортировка,",
                "пирамидальная сортировка и быстрая сортировка.",
                "Алгоритм состоит из повторяющихся проходов по сортируемому массиву.",
                "За каждый проход элементы последовательно сравниваются попарно и, если порядок в паре неверный, выполняется перестановка элементов."
            };

            fullText = string.Join(' ', strings);
        }
        
        [Test]
        public void SortWordsCorrectly()
        {
            var words = fullText.Split(new[] {' ', ',', '.', '!', '?', '-', ':', ';', '(', ')', '\'', '\"'});

            Sort<string>.ByBubble(words).sortedCollection.Should().ContainInOrder(words.OrderBy(x => x));
            Sort<string>.ByBubble(words,SortOrder.Descending).sortedCollection.Should().ContainInOrder(words.OrderByDescending(x => x));
        }
        
        [Test]
        public void SortStringsCorrectly()
        {
            Sort<string>.ByBubble(strings).sortedCollection.Should().ContainInOrder(strings.OrderBy(x => x));
            Sort<string>.ByBubble(strings, SortOrder.Descending).sortedCollection.Should().ContainInOrder(strings.OrderByDescending(x => x));
        }
        
        [Test]
        public void SortNumbersCorrectly()
        {
            var data = new[]
            {
                7, 234, 74, 2, 3, 7, 9, 3, 5, 7, 6, 8, 0, 134, 53, 56, 84, 345, 63, 23, 62, 34, 44, 56, 43, 15, 16, 17,
                11, 10
            };

            Sort<int>.ByBubble(data).sortedCollection.Should().ContainInOrder(data.OrderBy(x => x));
            Sort<int>.ByBubble(data,SortOrder.Descending).sortedCollection.Should().ContainInOrder(data.OrderByDescending(x => x));
        }

        [Test]
        public void CountOperationsCorrectly()
        {
            Sort<int>.ByBubble(new[] {1, 3, 2, 4}).totalOperations.Should().Be(6);
            Sort<int>.ByBubble(new[] {4, 1, 2, 3, 6, 6, 2}).totalOperations.Should().Be(30);
        }
    }
}