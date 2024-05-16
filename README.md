# TaskManager

TaskManager RESTful API project for CIP.

The TaskManager API provides endpoints for managing categories, products, and purchases. This README file provides an overview of the available endpoints and their functionality.

The base URL for accessing the TaskManager API is: localhost:8080/api

---

## CategoryController

### 1. Retrieve all categories

**URL**: /api/category  
**Method**: GET  
**Description**: Retrieves all categories.  
**Response**: A JSON array containing details of all categories.

### 2. Retrieve a specific category

**URL**: /api/category/{id}  
**Method**: GET  
**Description**: Retrieves a category by ID.  
**Path Parameter**:  
- id (Integer): The unique identifier of the category.  
**Response**: A JSON object containing the details of the category.

### 3. Add a new category

**URL**: /api/category  
**Method**: POST  
**Description**: Creates a new category.  
**Request Body**: A JSON object representing the new category.  
**Response**: A JSON object containing the details of the created category.

### 4. Update a category

**URL**: /api/category  
**Method**: PUT  
**Description**: Updates an existing category.  
**Request Body**: A JSON object representing the updated category.  
**Response**: No content.

### 5. Delete a category

**URL**: /api/category/{id}  
**Method**: DELETE  
**Description**: Deletes a category by ID.  
**Path Parameter**:  
- id (Integer): The unique identifier of the category.  
**Response**: No content.

---

## ProductController

### 1. Retrieve all products

**URL**: /api/product  
**Method**: GET  
**Description**: Retrieves all products.  
**Response**: A JSON array containing details of all products.

### 2. Retrieve a specific product

**URL**: /api/product/{id}  
**Method**: GET  
**Description**: Retrieves a product by ID.  
**Path Parameter**:  
- id (Integer): The unique identifier of the product.  
**Response**: A JSON object containing the details of the product.

### 3. Add a new product

**URL**: /api/product  
**Method**: POST  
**Description**: Creates a new product.  
**Request Body**: A JSON object representing the new product.  
**Response**: A JSON object containing the details of the created product.

### 4. Update a product

**URL**: /api/product  
**Method**: PUT  
**Description**: Updates an existing product.  
**Request Body**: A JSON object representing the updated product.  
**Response**: No content.

### 5. Delete a product

**URL**: /api/product/{id}  
**Method**: DELETE  
**Description**: Deletes a product by ID.  
**Path Parameter**:  
- id (Integer): The unique identifier of the product.  
**Response**: No content.

### 6. Restock a product

**URL**: /api/product/restock/{productId}  
**Method**: POST  
**Description**: Restocks a product with a specified quantity.  
**Path Parameter**:  
- productId (Integer): The unique identifier of the product.  
**Request Body**: An integer representing the quantity to add.  
**Response**: A message indicating the success or failure of the restocking operation.

---

## PurchaseController

### 1. Purchase products

**URL**: /api/purchase  
**Method**: POST  
**Description**: Allows users to purchase products by providing a list of product IDs.  
**Request Body**: A list of product IDs.  
**Response**: A JSON object containing details of the purchase, including total price, discount applied, and purchased products.

---

That concludes the documentation for the TaskManager API. You can use these endpoints to perform various operations on categories, products, and purchases.
