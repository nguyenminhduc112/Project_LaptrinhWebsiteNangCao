## Project Blog
> Chức Năng
1. Đăng nhập / Đăng ký
    
    1.1. User model

        - username -> nvarchar
        - password -> vachar
        - userId -> int
        - email -> varchar
        - displayName -> nvarchar
        - status -> int (-1:banned, 0:deactive, 1:active)
    
    1.2. Đăng ký tài khoản

        - Input: username, password, email, status = 1

    1.3. Reset mật khẩu

        - Input: username/ email
        - Output: gửi email reset mật khẩu

    1.4. Đăng nhập

        - Input: username , password
        - Output: json web Token/ refresh Token
    
    1.5. Đăng xuất

        - remove Token

    1.6. Hiển thị danh sách user
    
2. Article Manager

    2.1. Article Model
        
        - id
        - authorId (khóa ngoại)
        - title
        - content
        - categoryId (khóa ngoại)
        - tags
        - viewCount
        - createdAt
        - updatedAt
    
    2.2. Category Model

        - id
        - name

    2.3. Add Article

        - Input: title, content, tags, categoryId, authorId
    
    2.4. Edit Article 

        - Input: title, content, tags, categoryId
    2.5. Delete Article 

    2.6. Lấy nội dung bài viết dựa trên Id
        
        - Input: id
        - Output: acticle
    
    2.7. lấy danh sách bài viết của category

        - Input: categoryId
        - Output: array of article + paging
    
    2.8. lấy danh sách bài viết của tags

        - Input: tag
        - Output: array of article + paging

    2.9. lấy danh sách bài viết theo userId

        - Input: userId
        - Output: array of article + paging

3. Reaction

    3.1. Like bài viết

        - Input: authorId, articleId
4. Comment

    4.1. Comment Model

        - id
        - authorId
        - content
        - createdAt
        - updatedAt
    
    4.2. Thêm comment vào article

        - Input: content

    4.3. Sửa comment vào article

        - Input: content
    
    4.4. Xóa comment vào article

        - Input: content
5. Profile

    5.1. lấy danh sách bài viết theo userId

        -ref: 2.9

    5.2. hiển thị danh sách bài viết đã được bookmark

        - Input:
        - Output:
6. Share

    6.1. Build link share
7. Search

    7.1. Searh: tags, category, username, 

# Thơ Nhớ Như 
<div style='text-align:center'>
Sợi gió hoàng hôn se sắt <br>
Đong đưa chiếc lá thu vàng <br>
Ai vừa đi ngang rất vội, <br>
Hay là giọt nắng vừa tan? <br><br>

Dịu dàng mùa thu ghé tới<br>
Đường chiều ánh mắt hư vô<br>
Trời xanh một màu rất thực<br>
Nhưng em thì quá mơ hồ<br><br>

Ta như gã khờ phiêu bạt<br>
Mải mê những phiến chân trần<br>
Lời thương dùng dằng không ngỏ<br>
Thu về rụng trắng ngoài sân<br><br>

Chợt nghe hương mùa xao xuyến<br>
Người giờ như áng mây trôi<br>
Có kẻ ngẩn ngơ ngồi hát<br>
Dường như lại nhớ như rồi…<br> <brS>
</div>

><p style='text-align:right'>Tác giả: Nguyễn Minh Đức</p>

hello