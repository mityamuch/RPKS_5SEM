# RPKS_5SEM
# 1. Реализуйте набор сборок с типами, предназначенными для использования
архитектурного паттерна MVVM в приложениях WPF. Основные сборки:
1. <YourSurname>.Wpf.MVVM.Core: содержит базовые классы для
ViewModel, конвертеров значений (ValueConverter), конвертеров из
множества значений (MultiValueConverter), а также команд
(DelegateCommand или RelayCommand);
2. <YourSurname>.Wpf.MVVM: содержит классы конвертеров,
пронаследованных от базовых классов из вышеописанной сборки:
● Арифметический (операторы +, -, *, /, %);
● Проверки на равенство (операторы ==, !=);
● Проверки на отношение порядка (операторы >, >=, <, <=);
● Логический (операторы ||, &&, !);
● Поразрядный (операторы |, &, ~, ^);
● Проверки на null;
● Из значения типа bool;
, а также расширение разметки для поддержки вложенных
MultiBinding’ов
