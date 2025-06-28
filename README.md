
# 📄 API - ClimaApp
---

## 📌 Adicionar Relatório de temperatura

### **URL**
```
POST /api/relatorio/adicionar
```

### 📥 **Body (JSON) esperado**
```json
{
  "Cidade": "Rio de Janeiro",
  "solicitanteId": 1
}
```

### 📝 **Descrição dos Parâmetros**
| Campo           | Tipo    | Obrigatório | Descrição                                              | Exemplos         |
|-----------------|---------|-------------|--------------------------------------------------------|------------------|
| **Cidade**          | string  | Sim         | Cidade                                             | `"Rio de Janeiro", "São Paulo"` |
| **solicitanteId**   | int     | Sim         | ID do solicitante que está realizando a requisição | `1` |

### ✅ **Exemplo de chamada via cURL**
```bash
curl -X POST https://{{servidor}}/api/relatorio/adicionar \
-H "Content-Type: application/json" \
-d '{
  "Cidade": "Rio de Janeiro",
  "solicitanteId": 1
}'
```

### ✅ **Possíveis Códigos de Resposta**
| Status | Significado |
|---|---|
| **200 OK** | Relatório gerado e salvo com sucesso |
| **400 Bad Request** | Erro de validação nos parâmetros enviados ou falha ao consultar a API externa |
| **500 Internal Server Error** | Erro interno ao processar a requisição |

---

## 📌 Adicionar Solicitante

### **URL**
```
POST /api/solicitante/adicionar
```

### 📥 **Body (JSON) esperado**
```json
{
  "nome": "João da Silva"
}
```

### 📝 **Descrição dos Parâmetros**
| Campo   | Tipo   | Obrigatório | Descrição              | Exemplo           |
|-------- |--------|-------------|------------------------|-------------------|
| **nome** | string | Sim         | Nome completo do solicitante | "João da Silva" |

### ✅ **Exemplo de chamada via cURL**
```bash
curl -X POST https://{{servidor}}/api/solicitante/adicionar \
-H "Content-Type: application/json" \
-d '{
  "nome": "João da Silva"
}'
```

### ✅ **Possíveis Códigos de Resposta**
| Status | Significado |
|---|---|
| **201 Created** | Solicitante criado com sucesso |
| **400 Bad Request** | Erro de validação nos dados enviados |
| **500 Internal Server Error** | Erro interno ao processar a requisição |

---
