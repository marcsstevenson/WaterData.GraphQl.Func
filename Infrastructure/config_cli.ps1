# This is an example Azure CLI script to
# 1. create configuration values in an Azure App Configuration
# 2. create key vault values in an Azure Key Vault
# 3. create configuration values in an Azure App Configuration that link to secrets in an Azure Key Vault

# create configuration values in an Azure App Configuration
az appconfig kv set --name GraphQl-dev-func-config --key color --value red -y

# create key vault values in an Azure Key Vault
az keyvault secret set --vault-name GraphQl-dev-func-kv --name SecretName --value SecretValue

# create configuration values in an Azure App Configuration that link to secrets in an Azure Key Vault
az appconfig kv set-keyvault --name GraphQl-dev-func-config --key ConfigValueKey --secret-identifier https://refsys-dev-func-kv.vault.azure.net/secrets/SecretName -y