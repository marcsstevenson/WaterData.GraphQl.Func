This directory contains ARM (Azure Resource Manager) templates for the purpose of deploying Azure resources during deployment. The name of the script follows the naming convention for the resource - details here:

https://environmentcanterbury.sharepoint.com/sites/WaterDataTeam/SitePages/Azure%20Resource%20Naming%20Conventions.aspx

*** To login to Azure CLI

az login

    *** To set dev as the default subscription (which is where resource provisioning will be targeted)

    az account set -s dev

*** To Create a Resource Group (Azure DevOps has access for this and for a dev to test you need to use a personal account)

    *** Then create (validate first by swapping create for validate)

    az deployment Validate --template-file resource-group-deploy.json --location australiaeast --parameters environment=dev
    az deployment create --template-file resource-group-deploy.json --location australiaeast --parameters environment=dev

*** To Create the resources within the resoure group (eg resource group = waterdata-GraphQl-dev-func-rg)

    *** Then create (validate first by swapping create for validate)

    az group deployment Validate --resource-group waterdata-GraphQl-dev-func-rg --template-file resources-deploy.json --parameters environment=dev
    az group deployment create --resource-group waterdata-GraphQl-dev-func-rg --template-file resources-deploy.json --parameters environment=dev

*** To assign roles

    az group deployment Validate --resource-group waterdata-GraphQl-dev-func-rg --template-file role-assignments.json
    az group deployment create --resource-group waterdata-GraphQl-dev-func-rg --template-file role-assignments.json

*** Utils

    *** Tear down

        *** To delete a web app

        az webapp delete -n GraphQl-dev-func -g waterdata-GraphQl-rg

        *** To delete a service plan

        az appservice plan delete -n GraphQl-dev-func-hp -g waterdata-GraphQl-dev-func-rg

    *** Add your IP address to the IP restriction rules (if I had access :/ )

    az webapp config access-restriction add --resource-group waterdata-GraphQl-dev-func-rg --name waterdata-GraphQl-dev-func --rule-name "My Office" --action Allow --ip-address 203.86.204.7 --priority 101

    *** to list webapps

    az webapp list --output table

    *** to list function apps, selecting only name where name == 'HilltopWrapper-dev-func' and then filtering the results with a contains 'Hill'

    az functionapp list --query "[?name=='HilltopWrapper-dev-func'].{Name:name}[?contains(Name,'Hill')]" -o table

    *** to list AD groups of a given name containing

    az ad group list --query "[].{ObjectId: objectId, DisplayName:displayName}[?contains(DisplayName,'_WaterData_')]" -o table

    az ad group list --query "[?displayName=='AZ_ECAN_Developers_WaterData_Admin_Prod']

    AZ_ECAN_Developers_WaterData_User.objectId: 1d7d8317-dedf-43ea-989c-f4b81aece3b0

    AZ_ECAN_Developers_WaterData_Admin_Dev.objectId: 8267c0ca-5213-44ef-9331-dd5c1f8e7faa
    AZ_ECAN_Developers_WaterData_Admin_Test.objectId: 1a010094-b9e1-4bb0-ae3e-8b6386f3c93d
    AZ_ECAN_Developers_WaterData_Admin_Prod.objectId: ac4a34a6-b46b-4b09-96b2-c003cd7d8e3d

*** Scratch - for general development

    az group deployment Validate --resource-group waterdata-GraphQl-dev-func-rg --template-file config-deploy.json --parameters environment=dev
    az group deployment create --resource-group waterdata-GraphQl-dev-func-rg --template-file config-deploy.json --parameters environment=dev

GraphQl-dev-func principalId
-- 40fb69b8-edac-4ed5-94c2-8a28f17056b1
