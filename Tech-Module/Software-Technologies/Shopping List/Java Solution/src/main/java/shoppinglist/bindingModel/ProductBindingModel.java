package shoppinglist.bindingModel;

public class ProductBindingModel {
    private String name;
    private String status;
    private Integer priority;
    private Integer quantity;

    public String getName() {
        return name;
    }

    public ProductBindingModel setName(String name) {
        this.name = name;
        return this;
    }

    public String getStatus() {
        return status;
    }

    public ProductBindingModel setStatus(String status) {
        this.status = status;
        return this;
    }

    public Integer getPriority() {
        return priority;
    }

    public ProductBindingModel setPriority(Integer priority) {
        this.priority = priority;
        return this;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public ProductBindingModel setQuantity(Integer quantity) {
        this.quantity = quantity;
        return this;
    }
}
