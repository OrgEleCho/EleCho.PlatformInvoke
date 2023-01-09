# PlatformInvoke

这是一个致力于将所有 WinAPI 编写进 .NET 的库. 它使用了 C# 语言的命名与特性, 使得 WinAPI 的调用变得更加简单.

## 兼容性

本库编写与 WINVER 为 0x0A00 的环境中, 某些结构体的字段可能在旧系统中无法工作. 例如 DEVMODE 中 DM_SPECVERTION, 在不同系统版本中的取值也不一样

## 编写规范

1. 所有参数必须有正确的 In, Out, Optional 特性
2. 所有指针参数, 如若可以, 必须使用 ref 和 out
3. 所有函数必须使用大驼峰命名方式, 并不能包含字符集后缀. 自定义类型诸如 PAINTSTRUCT, 名称与成员名称必须使用大驼峰, 并删去类型前缀(有必要的话需要添加后缀补充说明).
4. 有必要则必须将定义的结构体名称改为全称, 例如 MSG 改为 Message, DevMode 改为 DeviceMode
5. 有必要则必须将成员简写改为全称, 例如 DlgFrame 需要改为 DialogFrame (但是 HTTP 这种大众皆知的缩写, 只需要使用 Http 即可)
6. 一般的, 不要对函数的参数名称进行更改, 除非使用了 ref 和 out, 则可以删去 lp 前缀
7. 自定义类型诸如 HDWP 这类本质是指针的类型, 必须使用 NativeType 特性来标记它在 C++ 中的类型名称, 但是 DWORD 这种基础类型不需要, 只需要使用对应的基本类型表示即可
8. 所有函数必须统一设置 SetLastError 为 false, 用户应该用本库封装好的 GetLastError 而不是调用 Marshal.GetLastPInvokeError
9. 所有的函数都应该显示指定 EntryPoint, 指定 ExactSpelling 为 true, 在使用到字符串的函数上应该指定对应字符集, 没使用到字符串的函数指定 None 字符集
10. 传入字符串的函数必须有两个重载, 一个字符串传 string, 另一个传 char*(ANSI 则是 byte*), 传出字符串也必须是两个重载, 一个传 StringBuilder, 另一个传 char*(ANSI 则是 byte*)
11. 所有定义的常量都必须在库中使用枚举进行定义, 去除前缀, 并改为大驼峰命名. 枚举类型的大小也必须指定, 例如 uint short 之类的

> 上述所有编写规范的前提是: 不能违反 .NET 代码编写规范与命名方式
