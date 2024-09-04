# YashGemJewelleries_API

Đọc phần này để sử dụng git

## Recommended IDE Setup

Sủ dụng Visual Studio hoặc Visual Studio Code để có được trải nghiệm tốt nhất trong khi code với ASP.NET Core API

## Note

Hãy luôn pull code từ nhánh master về vào lần đầu tiên code trong ngày.
Và hãy luôn đẩy code lên nhánh của mình vào cuối ngày.

## Project Setup

Tạo thư mục cần lưu project về

```sh
git clone https://github.com/AptechC2108G3/YashGemJewelleries-API.git
```

### Chuyển nhánh

Nếu chưa có nhánh -> tạo nhánh mới
```sh
git checkout -b lhnam
```
Thay đổi "lhnam" theo tên muốn đặt

Nếu đã có nhánh của mình
```sh
git checkout lhnam
```
Thay đổi lhnam theo tên nhánh sẵn có

### Lấy code từ nhánh master về nhánh của mình

```sh
git pull origin master
```

### Đẩy code từ nhánh của mình lên github
1. Lần đầu
```sh
git push --set-upstream origin lhnam
```
Thay "lhnam" bằng tên nhánh của mình

2. những lần tiếp theo
```sh
git push
```

### Các bước đẩy code lên github bằng terminal
1. Nén file thay đổi
```sh
git add .
```

2. Đóng gói file thay đổi
```sh
git commit -m "update file"
```
"update file" là tiêu đề của gói file thay đổi. Hãy đặt tiêu đề thật chuẩn xác để dễ tìm lại

3. Lấy code từ nhánh master về
```sh
git pull origin master
```
Việc lấy code từ nhánh master về để tránh khi bạn đẩy code lên bị conflict với code của người khác

4. Đẩy code
```sh
git push
``` 
