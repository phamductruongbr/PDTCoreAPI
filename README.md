### Cấu trúc Solution
- (Library) PDTCoreAPI.ServerData : Sử dụng entity Framework Core 3.1 để Migration database   
- (API) PDTCoreAPI.ServerAPI : Sử dụng Asp.net Core API để thao tác Select Insert Update Delete với database 
- (Client) PDTCoreAPI.UserClient : Sử dụng Jquery 3.2.1 và Bootstrap 3.3.7 để hiển thị dữ liệu, gọi tới API để thực thi và trả về Json data hiển thị lên giao diện người dùng 



### Start
- Migration database bằng PDTCoreAPI.ServerData
- Start PDTCoreAPI.ServerAPI ==> PDTCoreAPI.UserClient


### Note
Add-Migration Initial
Remove-Migration
update-database
drop-database


