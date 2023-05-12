# My_RestfulAPI
*.net 6 API*   
  
Table set  
![GITHUB]( https://i.imgur.com/tyjJwC4.png "SQL")
* Get
  * https://localhost:7249/api/InfoMessages
  * 查詢所有訊息
  * https://localhost:7249/api/InfoMessages/3
  * 查詢{id}的訊息
  * https://localhost:7249/api/Staff
  * 查詢所有職員
  * https://localhost:7249/api/Staff/3
  * 查詢{id}的職員
  * https://localhost:7249/api/Staff/all/Infomessages
  * 查詢所有職員以及發送過的訊息
  * https://localhost:7249/api/Staff/15/Infomessages
  * 查詢第{id}的職員以及發送過的訊息

* Post
  * https://localhost:7249/api/InfoMessages
  * 新增訊息
  * https://localhost:7249/api/Staff
  * 新增職員

* Put
  * https://localhost:7249/api/InfoMessages/41
  * 更新{id}的訊息
  * https://localhost:7249/api/Staff/15
  * 更新{id}的職員
Patch
  * https://localhost:7249/api/InfoMessages/3
  * 更新{id}的訊息
  * https://localhost:7249/api/Staff/1
  * 更新{id}的職員

* Delete
  * https://localhost:7249/api/InfoMessages/31
  * 刪除{id}的訊息
  * https://localhost:7249/api/InfoMessages/list/32,33
  * 刪除多個{id,id}的訊息
  * https://localhost:7249/api/Staff/18
  * 刪除{id}的職員 (包含該職員的訊息)
  * https://localhost:7249/api/Staff/list/17,16
  * 刪除多個{id,id}的職員 (包含該職員的訊息)
