https://en.cppreference.com/w/cpp/14

## C++11

### 别名模板

例如我们有一个

```cpp
typedef std::map<int, int> map_i_i;
typedef std::map<int, string> map_i_s;
```

 假设希望定义 std::map<int, 自主指定类型> ，可以使用using来定义模板别名

```
typelate<typename T>
using map_i_t = std::map<std::string, T>

int main()
{
    map_i_t<int> map_i_i;
    map_i_t<string> map_i_s;
    return 0;
}
```



## C++14

发布时间：2014年12月15日

### 语言新特性

- [variable templates](https://en.cppreference.com/w/cpp/language/variable_template)

​      早期C++模板只有类模板和函数模板两种类型 。C++11引入了[别名模板](# 别名模板)，而C++14则引入了变量模板。所以从C++14后有四种类型模板。

变量模板可以简化定义。在 C++14 中引入变量模板之前，参数化变量通常作为类模板的静态数据成员或返回所需值的 constexpr 函数模板实现。

- [generic lambdas](https://en.cppreference.com/w/cpp/language/lambda)
- lambda init-capture
- new/delete elision
- [relaxed restrictions on constexpr functions](https://en.cppreference.com/w/cpp/language/constexpr)
- [binary literals](https://en.cppreference.com/w/cpp/language/integer_literal)
- [digit separators](https://en.cppreference.com/w/cpp/language/integer_literal#Single_quote)
- [return type deduction for functions](https://en.cppreference.com/w/cpp/language/function#Return_type_deduction_.28since_C.2B.2B14.29)
- [aggregate classes](https://en.cppreference.com/w/cpp/language/aggregate_initialization) with default non-static member initializers.

### 新的lib库特性

- [std::make_unique](https://en.cppreference.com/w/cpp/memory/unique_ptr/make_unique)
- [std::shared_timed_mutex](https://en.cppreference.com/w/cpp/thread/shared_timed_mutex) and [std::shared_lock](https://en.cppreference.com/w/cpp/thread/shared_lock)
- [std::integer_sequence](https://en.cppreference.com/w/cpp/utility/integer_sequence)
- [std::exchange](https://en.cppreference.com/w/cpp/utility/exchange)
- [std::quoted](https://en.cppreference.com/w/cpp/io/manip/quoted)
- and many small improvements to existing library facilities, such as
  - two-range overloads for some algorithms
  - type alias versions of type traits
  - user-defined literals for [`basic_string`](https://en.cppreference.com/w/cpp/string/basic_string), [`duration`](https://en.cppreference.com/w/cpp/chrono/duration) and [`complex`](https://en.cppreference.com/w/cpp/numeric/complex)
  - etc.

## c++17

https://en.cppreference.com/w/cpp/17

