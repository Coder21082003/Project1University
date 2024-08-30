# Project1University

*** Hướng dẫn các layer trong project 

Common Data Layer (CDL):
Vai trò: Định nghĩa các thực thể (entities) hoặc mô hình dữ liệu được sử dụng trong toàn bộ hệ thống. Đây là nơi chứa các lớp mô hình đơn giản (POCOs/DTOs) mà không chứa bất kỳ logic nghiệp vụ nào.
Luồng hoạt động: Khi có yêu cầu từ Business Layer hoặc Data Access Layer cần truy xuất hoặc thao tác với dữ liệu, các lớp mô hình trong CDL sẽ được sử dụng để truyền dữ liệu giữa các lớp này.


Data Access Layer (DAL):
Vai trò: Thực hiện các thao tác với cơ sở dữ liệu, như truy vấn, cập nhật, xóa, và thêm mới dữ liệu. DAL chịu trách nhiệm tương tác trực tiếp với cơ sở dữ liệu thông qua các lớp trong CDL.
Luồng hoạt động: DAL sẽ nhận yêu cầu từ Business Layer, thực hiện các thao tác cần thiết với cơ sở dữ liệu, và trả kết quả dưới dạng các đối tượng CDL về cho Business Layer.


Business Layer (BL):
Vai trò: Xử lý logic nghiệp vụ của ứng dụng. BL chứa các quy tắc và luồng công việc của ứng dụng, đảm bảo dữ liệu được xử lý đúng cách trước khi gửi đến DAL hoặc nhận dữ liệu từ DAL để tiếp tục xử lý.
Luồng hoạt động: Khi có yêu cầu từ người dùng hoặc hệ thống (thông qua UI hoặc API), BL sẽ thực hiện logic nghiệp vụ cần thiết, sử dụng các lớp trong DAL để truy xuất hoặc ghi dữ liệu vào cơ sở dữ liệu. Kết quả cuối cùng sẽ được chuẩn bị trong BL và trả về cho UI hoặc hệ thống yêu cầu.


Còn UI layer chính là FE
