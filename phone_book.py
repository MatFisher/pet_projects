def show_data(filename: str):
    with open(filename, "r", encoding="utf-8") as f:
        print(f.read(), end="")


def add_data(filename: str):
    with open(filename, "a", encoding="utf-8") as f:
        fio = input("Введите ФИО: ")
        phone_number = input("Введите номер телефона: ")
        f.write(f"{fio} | {phone_number}\n")
        print(f"Добавлена запись : {fio} | {phone_number}")


def find_data(filename: str):
    search_line = input("Введите ФИО или номер для поиска: ")
    with open(filename, "r", encoding='utf-8') as f:
        tel_book = f.read()
        find_list = search(tel_book, search_line)
        return find_list


def find_one_line(filename: str):
    find_list = find_data(filename)
    if len(find_list) > 1:
        print("Найдены записи:")
        for index in range(len(find_list)):
            print(f"{index + 1} - {find_list[index]}")
        index_element = int(input("Введите номер записи для редактирования: ")) - 1
        print(f"Для редактирования выбрана запись - {find_list[index_element]}")
        return find_list[index_element]
    elif len(find_list) == 1:
        print(f"Для редактирования выбрана запись - {find_list[0]}")
        return find_list[0]
    else:
        print("Поиск не дал результатов.")
        return ""


def search(book: str, search_str: str):
    book = book.split("\n")
    result = []
    for line in book:
        if search_str in line:
            result.append(line)
    return result


def edit_data(filename: str):
    with open(filename, "r", encoding='utf-8') as f:
        tel_book = f.read()
    tel_book_lines = tel_book.split("\n")
    target_line = find_one_line(filename)
    while len(target_line) == 0:
        target_line = find_one_line(filename)
    edited_line = edit_line(target_line)
    tel_book_lines[tel_book_lines.index(target_line)] = edited_line
    print(f"Запись - {target_line}, изменена на - {edited_line}")
    with open(filename, "w", encoding='utf-8') as f:
        f.write("\n".join(tel_book_lines))


def edit_line(line: str):
    elements = line.split(" | ")
    fio = input("Введите ФИО: ")
    phone = input("Введите номер телефона: ")
    if len(fio) == 0:
        fio = elements[0]
    if len(phone) == 0:
        phone = elements[1]
    return f"{fio} | {phone}"


def remove_data(filename: str):
    with open(filename, "r", encoding='utf-8') as f:
        tel_book = f.read()
    tel_book_lines = tel_book.split("\n")
    find_list = find_data(filename)
    while len(find_list) == 0:
        find_list = find_data(filename)
    if len(find_list) > 0:
        print("Найдены записи:")
        for index in range(len(find_list)):
            print(f"{index + 1} - {find_list[index]}")
        index_for_remove = int(
            input("Введите номер строки для удаления, или 0 для удаления всех найденных строк: ")) - 1
        if 0 <= index_for_remove < len(find_list):
            print(f"Удалена запись: {find_list[index_for_remove]}")
            tel_book_lines.pop(tel_book_lines.index(find_list[index_for_remove]))
        elif index_for_remove == -1:
            for index in find_list:
                tel_book_lines.pop(tel_book_lines.index(index))
            print(f"Удалено записей: {len(find_list)}")
        else:
            print("Удалено записей: 0")
    with open(filename, "w", encoding='utf-8') as f:
        f.write("\n".join(tel_book_lines))


close = False
print("Программа для редактирование и отображения данных справочника.")
file_phone_book = "phone_book.txt"
with open(file_phone_book, "a", encoding="utf-8") as file:
    file.write("")

while not close:
    print("Введите: 1 - просмотр, 2 - добавление, 3 - поиск, 4 - изменение, 5 - удаление, 6 - выход")
    action = int(input("Действие: "))
    if action == 1:
        show_data(file_phone_book)
    elif action == 2:
        add_data(file_phone_book)
    elif action == 3:
        for i in find_data(file_phone_book):
            print(i)
    elif action == 4:
        edit_data(file_phone_book)
    elif action == 5:
        remove_data(file_phone_book)
    else:
        close = True