import { NgModule } from '@angular/core';
import { BrowserModule,} from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductManagementComponent } from './components/product-management/product-management.component';
import { HttpClientModule } from '@angular/common/http';
import { CategoryManagementComponent } from './components/category-management/category-management.component';
import { FormsModule } from '@angular/forms';
import { CategoryService } from './services/category.service';
import { ProductService } from './services/product.service';




@NgModule({
  declarations: [
    AppComponent,
    CategoryManagementComponent,
    ProductManagementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
 
  ],
  providers: [
    
    CategoryService, ProductService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
