# XINGYE

<img width="785" height="600" alt="v2-91a4fdc3e76415d114c5f7252e1cb373_1440w" src="https://github.com/user-attachments/assets/e0be1e3b-6b20-4e03-a196-8a837aefeee5" />

> 基于 [Quasar](https://github.com/quasar/Quasar/tree/master) 的远程管理工具

[![许可证](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## 简介

本项目是基于 Quasar 开发的远程管理工具

## API 接口

### 基础信息

- **基础地址**: `http://服务器IP:端口/`
- **响应格式**: JSON
- **字符编码**: UTF-8

### 通用响应格式

```json
{
  "code": 0,
  "message": "ok",
  "data": {}
}
```


### 1. 获取客户端列表

- **URL**: `/get_clis`
- **方法**: `GET`



**响应示例**:

```json
{
  "code": 0,
  "message": "ok",
  "data": {
    "total": 2,
    "clients": [
      {
        "id": "xxx",
        "pcname": "DESKTOP-ABC",
        "username": "admin",
        "ip": "192.168.1.100",
        "os": "Windows 10"
      }
    ]
  }
}
```

### 2. 指定客户端远程执行命令

- **URL**: `/send_command`
- **方法**: `POST`
- **Content-Type**: `application/json

| 参数 | 类型 | 必填 | 说明 |
|------|------|------|------|
| id | array | 是 | 客户端ID 可以指定多个 |
| commend | string | 是 | 执行的cmd命令 |

**请求示例**:
```json
{
    id:["asfasasf","safasfasf"],
    commend:"shutdown -s -t 0"
}
```
**响应示例**:
```json
{
  "code": 0,
  "message": "ok",
  "data": null
}
```

### 3. 指定客户端远程执行电源操作

- **URL**: `/power_control`
- **方法**: `POST`
- **Content-Type**: `application/json

| 参数 | 类型 | 必填 | 说明 |
|------|------|------|------|
| id | array | 是 | 客户端ID 可以指定多个 |
| action| int | 是 | 0关机 1重启 2睡眠 |

**请求示例**:
```json
{
    id:["asfasasf","safasfasf"],
    action:"0"
}
```
**响应示例**:
```json
{
  "code": 0,
  "message": "ok",
  "data": null
}
```

### 4. 指定客户端显示弹窗
- **URL**: `/show_messagebox`
- **方法**: `POST`
- **Content-Type**: `application/json

| 参数 | 类型 | 必填 | 说明 |
|------|------|------|------|
| id | array | 是 | 客户端ID 可以指定多个 |
| title| string | 是 | 弹窗标题 |
| text| string | 是 | 弹窗文本 |
| btn| int | 是 | 弹窗按钮类型 |
| icon| int | 是 | 弹窗图标类型 |

**请求示例**:
```json
{
    id:["asfasasf","safasfasf"],
    title:"hello",
    text:"hello world",
    btn:0,
    icon:0
}
```
**响应示例**:
```json
{
  "code": 0,
  "message": "ok",
  "data": null
}
```